using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject pause;

    [SerializeField]
    AudioSource boop;

    [SerializeField]
    GameObject onScreen;

    [SerializeField]
    GameObject helpScreen;

    [SerializeField]
    GameObject mainScreen;

    bool pauseActive = false;
    #endregion
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive == true)
            {
                boop.Play();
                Time.timeScale = 1f;
                onScreen.SetActive(true);
                pause.SetActive(false);
                pauseActive = false;
            }
            else if (pauseActive == false)
            {
                boop.Play();
                Time.timeScale = 0f;
                onScreen.SetActive(false);
                pause.SetActive(true);
                pauseActive = true;
            }
        }
    }

    public void Help()
    {
        boop.Play();
        mainScreen.SetActive(false);
        helpScreen.SetActive(true);
    }

    public void Back()
    {
        boop.Play();
        mainScreen.SetActive(true);
        helpScreen.SetActive(false);
    }
}
