using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour
{
    [SerializeField]
    int rotationOffset = 90;

	void Update ()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;      //subtracting player position from mouse position.
        difference.Normalize();         // normalizing the vector, making the sum of the vectors = 1.
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;      //finding the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);
	
	}
}
