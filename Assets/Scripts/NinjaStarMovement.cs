using UnityEngine;
using System.Collections;

public class NinjaStarMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed = 10f;

    void Update()
    {
        Debug.Log("I'm a bullet");
    }
}
