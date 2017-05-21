using UnityEngine;

public class ObjectPoolCameraFollow : MonoBehaviour
{
    [SerializeField] private  float panSpeed = 2.0f;
    [SerializeField] private  float turnSpeed = 2.0f;
    [SerializeField] private  float zoomSpeed = 2.0f;
    [SerializeField] private  float zoomSpeedA = 2.0f;
    [SerializeField] private bool auto;
    [SerializeField] private Vector2 autoPanSpeed;
    [SerializeField] private bool isPanning;
    [SerializeField] private bool isRotating;
    [SerializeField] private bool isZooming;
    [SerializeField] private bool keyboardMode;
    private Vector3 mouseOrigin;
    private Vector3 move;
    [SerializeField] private float panRange;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float shiftBoost;
    private Vector3 startPos;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 zoomRange;

    private void Update()
    {
        startPos = transform.position;
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, rotateSpeed*Time.deltaTime);
        shiftBoost = Input.GetKey(KeyCode.LeftShift) ? 1.2f : 0.0f;

        if (!auto)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseOrigin = Input.mousePosition;
                isZooming = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                mouseOrigin = Input.mousePosition;
                isPanning = true;
            }

            if (!Input.GetMouseButton(0)) isZooming = false;
            if (!Input.GetMouseButton(1) && !keyboardMode) isPanning = false;

            if (isRotating)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                transform.RotateAround(transform.position, Vector3.up, pos.x*(turnSpeed + shiftBoost));
            }

            if (isPanning)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
                if (!keyboardMode)
                {
                    move = new Vector3(pos.x*(panSpeed + shiftBoost), pos.y*(panSpeed + shiftBoost), 0);
                }
                else
                {
                    move = new Vector3(Input.GetAxis("Horizontal")*(panSpeed + shiftBoost)*Time.deltaTime,
                        Input.GetAxis("Vertical")*(panSpeed + shiftBoost)*Time.deltaTime);
                }

                transform.Translate(move, Space.Self);
                if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) > panRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0),
                        (50 + shiftBoost)*Time.deltaTime);
                }
            }

            if (isZooming)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                Vector3 move = pos.y*(zoomSpeed + shiftBoost)*transform.forward;
                transform.Translate(move, Space.World);
                ZoomRange();
            }
        }
        else
        {
            if (isPanning)
            {
                transform.Translate(autoPanSpeed, Space.Self);
            }
        }
    }

    private void ZoomRange()
    {
        Vector3 zoom = (Vector3.Distance(transform.position, target.position) > zoomRange.y)
            ? Vector3.up*(Vector3.Distance(transform.position, target.position))
            : (Vector3.Distance(transform.position, target.position) < zoomRange.x) ? Vector3.down : Vector3.zero;
        transform.Translate((zoom.y/10)*(zoomSpeedA + shiftBoost)*transform.forward, Space.World);
    }

    public void SetTarget(Transform toSet)
    {
        target = toSet;
    }
}