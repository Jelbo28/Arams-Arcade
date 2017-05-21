using System;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    [SerializeField] private int currLevel;
    private DisplayManager displayManager;
    private bool gameOver;
    [SerializeField] private PipeLevel[] levels;
    [SerializeField] private float levelTimer;
    public MinigameController minigameController;
    private RadialProgressMeter progressMeter;

    private void Start()
    {
        minigameController = FindObjectOfType<MinigameController>();
        displayManager = FindObjectOfType<DisplayManager>();
        progressMeter = FindObjectOfType<RadialProgressMeter>();
        BeginGame();
    }

    private void Update()
    {
        if (currLevel > 0 && !gameOver)
        {
            if (levelTimer > 0)
                levelTimer -= Time.deltaTime;
            else
            {
                Time.timeScale = 1;
                levels[currLevel - 1].catalystPipe.SetTrigger("PipeGo");
            }
        }
        else
        {
            displayManager.EndGameScreen();
        }
    }

    public void SetLevel()
    {
        if (currLevel < levels.Length)
        {
            if (currLevel != 0)
                levels[currLevel - 1].levelObject.SetActive(false);
            progressMeter.Activate(levels[currLevel].levelTimer);
            levelTimer = levels[currLevel].levelTimer;
            levels[currLevel].levelObject.SetActive(true);
            currLevel++;
        }
        else
        {
            Time.timeScale = 1;
            gameOver = true;
        }
    }

    private void BeginGame()
    {
        displayManager.BeginGame();
        SetLevel();
    }

    [Serializable]
    public class PipeLevel
    {
        public Animator catalystPipe;
        public GameObject levelObject;
        public int levelTimer;
    }
}