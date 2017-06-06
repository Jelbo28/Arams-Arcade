using UnityEngine;
using System.Collections;

public class EnemyActions : MonoBehaviour {

    // Serialized variables

    [SerializeField] float m_Speed;

    // public variables

    public bool yes;

    // private variables

    Animator m_Anim;
    Rigidbody2D m_Rb;
    Vector2 forward;
    Vector2 backwards;

    // private methods

    void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_Rb = GetComponent<Rigidbody2D>();
        forward = new Vector2(m_Speed, 0);
        backwards = new Vector2(-m_Speed, 0);
        yes = true;
    }

    void FixedUpdate()
    {
        
        if (yes)
        {          
            m_Rb.velocity = forward;
            m_Anim.SetBool("Switch", false); 
        }
        else if (!yes)
        {
            m_Rb.velocity = backwards;
            m_Anim.SetBool("Switch", true);
        }
    }  

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            yes = !yes;
        }
    }

}
