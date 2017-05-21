using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressSpace : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Text space;

    [SerializeField]
    GameObject fade;

    [SerializeField]
    GameObject controls;

    [SerializeField]
    GameObject story;

    AudioSource boop;
    int timesPressed = 0;
    #endregion

    void Awake()
    {
        boop = gameObject.GetComponent<AudioSource>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timesPressed >= 1)
            {
                boop.Play();
                timesPressed++;
                fade.SetActive(true);
            }
            if (timesPressed < 1)
            {
                boop.Play();
                timesPressed++;
                story.SetActive(false);
                controls.SetActive(true);
                space.text = "Press Space To Play";
            }
        }
    }
}
