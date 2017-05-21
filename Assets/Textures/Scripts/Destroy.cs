using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    GameObject GM;

    [SerializeField]
    bool autoScore;

    float scoreValue;
    float rigidMass;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("poop");
        if (coll.gameObject.tag == "Destroyable Object")
        {
            rigidMass = coll.gameObject.GetComponent<Rigidbody2D>().mass;
            Destroy(coll.gameObject);
            Score();
            //GM.GetComponent<BreakoutGM>().UpdateScore(scoreValue);
            //Debug.Log(coll.gameObject.GetComponent<Rigidbody2D>().mass);
            gameObject.SetActive(false);
        }

        else if(coll.gameObject.tag != "Player1" || coll.gameObject.tag != "PlayerPart")
        {
            gameObject.SetActive(true);
        }

        else if (coll.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }

    void Score()
    {
        if (autoScore == true)
        {
            scoreValue = rigidMass;
        }
        else
        {
            scoreValue = 1f;
        }
    }
}
