using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<PauseManager>().Reset();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Peaceful Princess Uprising");
    }

    public void Play()
    {
        SceneManager.LoadScene("Peaceful Princess Uprising_1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
