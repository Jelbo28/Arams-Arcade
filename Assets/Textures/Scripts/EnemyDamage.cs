using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
