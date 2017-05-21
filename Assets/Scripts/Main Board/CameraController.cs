using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    private Camera cam;
    [SerializeField] private float dampTime;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform target;
    private Vector3 velocity = Vector3.zero;
    // Use this for initialization
    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        var step = moveSpeed*Time.deltaTime;
        cam.transform.position = Vector3.MoveTowards(transform.position, anchor.position, step);
        var turn = rotateSpeed*Time.deltaTime;
        cam.transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.LookRotation(target.transform.position - transform.position), turn);
    }
}