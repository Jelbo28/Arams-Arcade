using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    float upSpeed;
    [SerializeField]
    float turnSpeed;

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * upSpeed * Time.deltaTime);
	}
}
