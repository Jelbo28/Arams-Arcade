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
    [SerializeField]
    private Animator fadeAnimator;

    private float delay;
    private bool quit;
    public string sceneAfter;
    [SerializeField] public bool howPlay = false;
    private void Start()
    {
        fadeAnimator = FindObjectOfType<ScoreManager>().GetComponentInChildren<Animator>();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneByName(string sceneName)
    {
        if (!howPlay)
        {
            StartCoroutine(SceneDelay(sceneName));

        }
        else
        {
            //sceneAfter = sceneName;
            StartCoroutine(SceneDelay(sceneAfter));
            howPlay = false;
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
        StartCoroutine(SceneDelay(sceneNumber.ToString()));
    }

    public void SetDelay(float delaySet)
    {
        delay = delaySet;
    }



    private IEnumerator SceneDelay(string scene)
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(delay);
        if (!quit)
        {
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