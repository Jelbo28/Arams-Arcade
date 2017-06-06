using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {
    [SerializeField]
    float moveSpeed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Set moveDirection to the vertical axis (up and down keys) * speed
        Vector3 moveDirection = new Vector3(moveSpeed * Input.GetAxis("Horizontal"), 0, moveSpeed * Input.GetAxis("Vertical"));
        //Transform the vector3 to local space
        moveDirection = transform.TransformDirection(moveDirection);
        //set the velocity, so you can move
        transform.GetComponent<Rigidbody>().velocity = new Vector3(moveDirection.x, 0, moveDirection.z);
        //GetComponent<Rigidbody>().AddForce(Vector3.up * -10);

    }
}
