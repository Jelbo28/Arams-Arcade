using UnityEngine;
using System.Collections;

public class RobotRenderer : MonoBehaviour
{
    #region Variables

    [SerializeField]
    Sprite left;

    [SerializeField]
    Sprite right;

    [SerializeField]
    Sprite idle;

    [SerializeField]
    AudioSource hover;

    bool working = false;

    float pause;

    #endregion

    void Update ()
    {
        pause = Input.GetAxis("Horizontal");
        if (!working)
        {
            RenderRobot();
        }
    }

    void RenderRobot()
    {
        working = true;
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().sprite = left;
            if (!hover.isPlaying)
            {
                hover.Play();
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().sprite = right;
            if (!hover.isPlaying)
            {
                hover.Play();
            }
        }
        else if (Input.GetAxis("Horizontal") == pause)
        {
            GetComponent<SpriteRenderer>().sprite = idle;
            hover.Stop();
        }
        //Debug.Log(Input.GetAxis("Horizontal"));
        working = false;
    }
}
