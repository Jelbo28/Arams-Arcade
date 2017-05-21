using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    float monsterSpeed;

    Animator monsterAnim;
    Rigidbody2D monsterRig;

    bool goRight = true;


    Vector2 left;

    Vector2 right;

    #endregion




    void Awake()
    {
        monsterAnim = GetComponent<Animator>();
        monsterRig = GetComponent<Rigidbody2D>();
        right = new Vector2(monsterSpeed, 0);
        left = new Vector2(-monsterSpeed, 0);
    }

    void FixedUpdate()
    {
        if (goRight)
        {
            monsterRig.velocity = right;
            monsterAnim.SetTrigger("GoRight");
        }
        else if (!goRight)
        {
            monsterRig.velocity = left;
            monsterAnim.SetTrigger("GoLeft");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            if (goRight == true)
            {
                goRight = false;
            }
            else if (goRight == false)
            {
                goRight = true;
            }
        }
    }
}
