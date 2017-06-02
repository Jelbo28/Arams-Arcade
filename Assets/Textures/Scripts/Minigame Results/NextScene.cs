using UnityEngine;
using UnityEngine.Audio;

public class NextScene : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey = KeyCode.Space;
    [SerializeField] public bool instaQuit;
    private SceneChanger sceneChanger;
    [SerializeField] private string sceneTo;
    [SerializeField] private bool userInput;
    // Use this for initialization
    private void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
        sceneTo = sceneChanger.sceneAfter;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(inputKey) && userInput)
        {
            SetDelay(1f);
            ChangeScene(sceneTo);
        }
    }

    public void ChangeScene(string scene = "")
    {
        if (!instaQuit)
        {
            if (sceneTo == "")
            {
                //Debug.Log("pixxa");
                sceneChanger.LoadSceneByName(scene);
            }
            else
            {
                sceneChanger.LoadSceneByName(sceneTo);
            }
        }
        else
        {
            Application.Quit();
        }
    }

    public void HowToPlay(string scene)
    {
        ChangeScene("Minigame Rules");
        sceneChanger.howPlay = true;
        sceneChanger.sceneAfter = scene;
        sceneChanger.SetMinigameInfo();
    }

    public void SetDelay(float delaySet)
    {
        sceneChanger.SetDelay(delaySet);
    }

    public void Quit()
    {
        instaQuit = true;
    }
}