using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float destroyTimer;
    [SerializeField]
    bool blob = false;

    private float initalDestroy;
    private bool collision = false;

    void Start()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        initalDestroy = destroyTimer;
    }

    void Update ()
    {
        destroyTimer -= Time.deltaTime;
        transform.position += -transform.right * speed * Time.deltaTime;
        if (destroyTimer < initalDestroy - 0.1f && collision == false)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (blob)
        {
            if (other.gameObject.tag == "Player")
            {
                collision = true;
                other.gameObject.GetComponent<Damager>().Attacked(0.25f);
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
