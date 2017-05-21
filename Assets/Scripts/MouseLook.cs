using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    float sensitivityY = 15f;
    [SerializeField]
    float minimumY = -60f;
    [SerializeField]
    float maximumY = 60f;
    float rotationY = 0f;
    Quaternion originalRotation;
	
	void Update ()
    {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.forward);
        transform.localRotation = originalRotation * yQuaternion;
	
	}

    void Start()
        { if (GetComponent<Rigidbody2D>())
            GetComponent<Rigidbody2D>().freezeRotation = true;
        originalRotation = transform.localRotation;}
                
      

        public static float ClampAngle (float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360f) angle += 360f;
        return Mathf.Clamp(angle, min, max);

    }

    }
