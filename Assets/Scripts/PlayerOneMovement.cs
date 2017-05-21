using UnityEngine;
using System.Collections;

public class PlayerOneMovement : MonoBehaviour 
{
    bool ducking = false;
	float speed = 0.1f;
	float jumpPower = 800;
	private Vector2 playerPosition = new Vector2 (0, 0);
	private Rigidbody2D playerRigidbody;
	int OffGround = 0;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	void Update () 
	{
		//Debug.Log (OffGround);
		CheckRunning ();
	    Jump ();
        Walk ();
	}

    void Walk()
    {
        if (ducking == false)
        {
            float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * speed);
            //float yPosition = transform.position.y + (Input.GetAxis ("Vertical") * speed);
            playerPosition = new Vector2(xPosition, transform.position.y);
            transform.position = playerPosition;
            if (Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("IsWalking", false);
            }
            else if (Input.GetAxis("Horizontal") != 0)
            {
                anim.SetBool("IsWalking", true);
            }
            if (Input.GetKey("a") == true)
            {
                anim.SetBool("WalkingLeft", true);
                //transform.localScale = new Vector2(-1.5f, transform.localScale.y);
            }
            else if (Input.GetKey("d") == true)
            {
                anim.SetBool("WalkingLeft", false);
                //transform.localScale = new Vector2(1.5f, transform.localScale.y);
            }
        }  
    }

	void Jump()
	{
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		if (Input.GetButtonDown("Jump") && OffGround < 3)
		{
			//Debug.Log("Jump");
			playerRigidbody.AddForce(new Vector2(0, jumpPower));
			OffGround++;
            anim.SetBool("IsJumping", true);
        }
	}

	void CheckRunning()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = 0.3f;
            anim.SetFloat("RunningSpeed", 3);
		}
		else
		{
			speed = 0.1f;
            anim.SetFloat("RunningSpeed", 1);
        }

        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            anim.SetBool("IsDucking", true);
            ducking = true;
        }
        else if (Input.GetKeyUp(KeyCode.S) == true)
        {
            anim.SetBool("IsDucking", false);
            ducking = false;
        }
    }


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject || coll.gameObject.tag == "Player 2")
		{
			OffGround = 0;
            anim.SetBool("IsJumping", false);
        }
	}
}
