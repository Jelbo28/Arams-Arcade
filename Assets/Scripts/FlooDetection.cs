using UnityEngine;
using System.Collections;

public class FlooDetection : MonoBehaviour 
{
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponentInParent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Ground") {
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;

			this.gameObject.transform.rotation = other.transform.rotation;
		} 

	}

	void OnTriggerExit2D(Collider2D other)
	{
		rb.constraints = RigidbodyConstraints2D.None;
	}
}
