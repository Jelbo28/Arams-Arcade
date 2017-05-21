using UnityEngine;
using System.Collections;

public class BrotherMovement : MonoBehaviour
{
    [SerializeField]
    bool m_HitRightWall = false;

    [SerializeField]
    bool m_HitLeftWall = true;

    public float m_Speed;

    void Update()
    {
        if (m_HitLeftWall == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime* m_Speed);
        }
        if (m_HitRightWall == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * m_Speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RightWall")
        {
            m_HitRightWall = true;
            m_HitLeftWall = false;
        }
        if (other.tag == "LeftWall")
        {
            m_HitRightWall = false;
            m_HitLeftWall = true;
        }
    }
}
