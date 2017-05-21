using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mash : MonoBehaviour
{
    #region Variables
    [SerializeField]
    int mashAmmount = 0;
    [SerializeField]
    float repeatRate = 1f;
    bool start = false;
    bool winBool = false;
    Sprite princess;
    int count;
    [SerializeField]
    GameObject space;


    [SerializeField]
    GameObject win;

    [SerializeField]
    Text countText;

    [SerializeField]
    Sprite[] state;

    [SerializeField]
    AudioSource[] yawn;
    #endregion

    void Update ()
    {
        if (!start)
        {
            InvokeRepeating("Fall", 0f, repeatRate);
            start = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (!winBool)
            {
                mashAmmount++;
                count++;
                ChangeSprite();
            }
            space.GetComponent<SpacePulse>().Pulse();
        }
        //Debug.Log(mashAmmount);
	}

    void Fall()
    {
        if (mashAmmount >= 0)
        {
            mashAmmount--;
        }
        //Debug.Log(mashAmmount);
    }

    void ChangeSprite()
    {
        if (mashAmmount == 0)
        {
            princess = state[0];
        }
        else if (mashAmmount == 12)
        {
            mashAmmount = mashAmmount + 3;
            yawn[0].Play();
            princess = state[1];
        }
        else if (mashAmmount == 25)
        {
            mashAmmount = mashAmmount + 3;
            yawn[1].Play();
            princess = state[2];
        }
        else if (mashAmmount == 37)
        {
            mashAmmount = mashAmmount + 3;
            yawn[2].Play();
            princess = state[3];
        }
        else if (mashAmmount == 50)
        {
            yawn[3].Play();
            princess = state[4];
            winBool = true;
            countText.text = "You hit space " + count + " times to wake her up!";
            win.SetActive(true);
            CancelInvoke();
            //repeatRate = 0.6f;
            //start = false;
            //Win();
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = princess;
    }


}
