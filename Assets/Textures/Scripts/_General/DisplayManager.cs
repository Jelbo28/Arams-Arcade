using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] private float endDelay;
    [SerializeField] private Animator Fade;
    [SerializeField] private GameObject[] GameText;
    private string origText;
    [SerializeField] private Text PtsText;
    private SceneChanger sceneChanger;
    public bool endGame = false;

    private void Start()
    {
        Fade = FindObjectOfType<ScoreManager>().GetComponentInChildren<Animator>();
        origText = PtsText.text;
        PtsText.text = origText + 0;
        sceneChanger = FindObjectOfType<SceneChanger>();
        Fade.SetTrigger("FadeIn");
    }

    private void Update()
    {
        if (endGame)
        {
            EndGameScreen();
        }
    }

    public void BeginGame()
    {
        GameText[0].SetActive(true);
    }

    public void EndGameScreen()
    {
        GameText[1].SetActive(true);
        endDelay -= Time.deltaTime;
        if (!(endDelay <= 3)) return;
        GameText[1].GetComponent<Text>().text = "Ending in... " + Mathf.RoundToInt(endDelay);
        if (!(endDelay <= 1.5f)) return;
        Fade.SetTrigger("FadeOut");
        if (!(endDelay <= 0.5f))
        {
            Cursor.visible = true;
            sceneChanger.LoadSceneByName("Minigame Results");
            endGame = false;
        }
    }

    public void UpdatePoints(float value)
    {
        PtsText.text = origText + value;
    }
}