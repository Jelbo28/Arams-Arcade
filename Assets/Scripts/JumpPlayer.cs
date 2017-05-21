using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour {

    [SerializeField]
    float jumpForce;
    [SerializeField]
    float jumpWait;
    [SerializeField]
    float colorChangeSpeed;

    Rigidbody rbody;
    private bool onGround;
    private bool firstTime = true;
    private float jumpLock;
    private int spacePressed;

    private float timePassed;
    private float startingYPos;
    private JumpDisplayManager displayManager;
    private AudioManager audioManager;
    //private HSBColor cubeColor;


    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
        displayManager = GameObject.FindObjectOfType<JumpDisplayManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        startingYPos = transform.position.y;

    }

    // Update is called once per frame
    void Update () {
        timePassed += Time.deltaTime;
        //Debug.Log("Speed: " + (transform.position.y - startingYPos) / timePassed);
        Jump();
        //ColorModify();
		
	}

    //void ColorModify()
    //{
    //    cubeColor = new HSBColor (GetComponent<Renderer>().material.color);
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        cubeColor.h += .05f;
    //       // Debug.Log("boob");
    //    }
    //    Colorx.Slerp(GetComponent<Renderer>().material.color, cubeColor.ToColor(), colorChangeSpeed * Time.deltaTime);
    //    //GetComponent<Renderer>().material.color = cubeColor.ToColor();

    //}

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpLock <= 0)
        {
            rbody.AddForce(Vector3.up * jumpForce);
            audioManager.PlaySound(false);
            jumpLock = jumpWait;
            spacePressed++;
        }

        if (jumpLock > 0)
        {
            jumpLock -= Time.deltaTime;
        }
        else
        {
            jumpLock = 0;
        }
    }

    void CheckObjective()
    {
        if (spacePressed > 0 && onGround)
        {
            displayManager.mainText.text = "Good job!";
            //Debug.Log("Winning!");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("joe");
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            if (!firstTime)
            {
                if (rbody.velocity.y < 0.5f)
                {
                    audioManager.PlaySound(true);
                    rbody.velocity = Vector3.zero;
                }
                else
                {
                    audioManager.PlaySound(false);
                }


            }
            firstTime = false;
            CheckObjective();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
