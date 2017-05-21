using UnityEngine;
using System.Collections;

public class PartActions : MonoBehaviour {

    // public variables

    

    // private variables

    //Collider2D box;
    PartsSpawn manager;

    // private methods

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PartsSpawn>();
        //box = gameObject.GetComponent<Collider2D>();
        //box.enabled = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //box.enabled = true;
        }
    }

    //void OnCollisionEnter2D (Collision2D other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //       manager.count--;
    //       Destroy(gameObject, 1.0f);
    //    }
    //}

}
