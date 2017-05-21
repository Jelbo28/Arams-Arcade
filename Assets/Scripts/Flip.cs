using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {

    float x = 0;
    float y = 360;
    float z = 0;

	void OnCollisionEnter2D (Collision2D other)
    {
	    if(other.gameObject.tag == "Ground")
        {
            Debug.Log("Collide");
            this.gameObject.transform.rotation = other.transform.rotation;
        }
	}
}
