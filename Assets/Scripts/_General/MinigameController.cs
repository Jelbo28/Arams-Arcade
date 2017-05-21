using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;
    private int dataPts;
    public DisplayManager displayManager;
    [SerializeField] private List<MonoBehaviour> scripts;
    [SerializeField] private float startDelay;
    [SerializeField] public GameObject[] stuffToDisable;
    [SerializeField] private MonoBehaviour[] thangs;
    public PlayerInfo thisPlayer;

    private void Start()
    {
        foreach (PlayerInfo player in FindObjectOfType<ScoreManager>().players)
        {
            if (player.thisUser)
            {
                thisPlayer = player;
                break;
            }
        }
        displayManager = FindObjectOfType<DisplayManager>();
        foreach (GameObject stuff in stuffToDisable)
        {
            //stuff.GetComponents(typeof(MonoBehaviour));
            foreach (MonoBehaviour script in stuff.GetComponents(typeof (MonoBehaviour)))
            {
                scripts.Add(script);
            }
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            foreach (Animator anim in stuff.GetComponents(typeof (Animator)))
            {
                animators.Add(anim);
            }
            foreach (Animator anim in animators)
            {
                anim.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (startDelay >= 0)
        {
            startDelay -= Time.deltaTime;
        }
        else
        {
            BeginGame();
        }
    }

    private void BeginGame()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
        foreach (Animator anim in animators)
        {
            anim.enabled = true;
        }
        displayManager.BeginGame();
    }

    public void AddPoints(int ammount)
    {
        dataPts += ammount;
        thisPlayer.mingamePts = dataPts;
        displayManager.UpdatePoints(dataPts);
    }
}