using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	float speed = 120f;

    [SerializeField]
    Animator anim;  

	private bool m_CannotJump;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

		m_CannotJump = false;
    }

	void FixedUpdate ()
    {
		

        rb.GetComponent<Rigidbody2D>();

		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (Vector3.left * speed);
			anim.SetBool ("GoingRight", false);
			anim.SetBool ("GoingLeft", true);
		}
		else if (Input.GetKey (KeyCode.D)) 
		{
			rb.AddForce (Vector3.right * speed);
			anim.SetBool ("GoingLeft", false);
			anim.SetBool ("GoingRight", true);
		} 
		else if (Input.GetKeyDown (KeyCode.W)) 
		{
			if (m_CannotJump == false) 
			{
				m_CannotJump = true;

				rb.AddForce (Vector3.up * 450);
				ResettingTheBool();
			}
		} 
		else
		{
			anim.SetBool("GoingLeft", false);
			anim.SetBool("GoingRight", false);
		}
	}

	void ResettingTheBool()
	{
		StartCoroutine (ResetTheBool());
	}

	IEnumerator ResetTheBool()
	{
		yield return new WaitForSeconds (1.2f);

		m_CannotJump = false;
	}

}

