using UnityEngine;
using System.Collections;

public class LeverPull : MonoBehaviour
{
    [SerializeField]
    GameObject brother;
    [SerializeField]
    bool toggle;
    [SerializeField]
    Sprite leverDown;
    [SerializeField]
    GameObject mud;
    [SerializeField]
    Animator fade;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NinjaStar")
        {
			toggle = true;
        }
    }

    void Update()
    {
        if (toggle == true)
        {
			brother.GetComponent<PolygonCollider2D>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().sprite = leverDown;
			mud.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            fade.SetBool("End", true);
        }
    }
}
