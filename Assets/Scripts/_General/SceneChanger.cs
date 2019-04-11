using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [System.Serializable]
    public class MinigameInfo
    {
        public string minigameName;
        public string gameInfo;
    }

    [SerializeField] private MinigameInfo[] allMinigames = new MinigameInfo[6];
    public MinigameInfo currentMinigame;

    private float delay;
    [SerializeField]
    private bool quit;
    public string sceneAfter;
    [SerializeField] private string howToPlay;
    [SerializeField] public bool howPlay = false;
    private NextScene rulesNext;
    private void Start()
    {
      // Cursor.visible = true;
        if (howPlay)
            rulesNext = FindObjectOfType<NextScene>();
        //DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneByName(string sceneName = "")
    {
        if (sceneName != "Level_Main")
        {
            if (!howPlay)
            {
                //SetMinigameInfo();
                SceneDelay(howToPlay);
                howPlay = true;
            }
            else
            {
                //sceneAfter = sceneName;
                GetComponent<PauseManager>().Reset();
                SceneDelay(sceneAfter);
                howPlay = false;
            }
        }
        else
        {
            SceneDelay(sceneName);
        }
    }

    public void SetMinigameInfo()
    {
        foreach (MinigameInfo minigame in allMinigames)
        {
            if (minigame.minigameName == sceneAfter)
                currentMinigame = minigame;
        }
    }

    public void LoadSceneByIndex(int sceneNumber)
    {
        SceneDelay(sceneNumber.ToString());
    }

    public void SetDelay(float delaySet)
    {
        delay = delaySet;
    }



    public void SceneDelay(string scene)
    {
        if (!quit)
        {
            //GetComponent<MouseVisible>().Lock();
            SceneManager.LoadScene(scene);
        }
        else
        {
            Application.Quit();
        }
    }

    public void Quit()
    {
        quit = true;
    }
}