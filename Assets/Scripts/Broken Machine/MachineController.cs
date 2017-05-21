using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    [SerializeField] private bool AIControl;
    [SerializeField] private float AITimer;
    [SerializeField] private Vector2 AITimerRange;
    private BrokenMachine manager;
    [SerializeField] private List<BrokenPart> parts;
    [SerializeField] private int playerNum;
    [SerializeField] private bool reset;
    [HideInInspector] public PlayerInfo currPlayer;
    //private int partNum = 0;

    public bool gameOver = false;
    private void Awake()
    {
        currPlayer = FindObjectOfType<ScoreManager>().players[playerNum - 1];
        manager = FindObjectOfType<BrokenMachine>();
        //Debug.Log(name + " ," + (playerNum - 1))     ;
        //Debug.Log(name + " = " +currPlayer);
        //currPlayer = players[playerNum - 1];
        //Debug.Log(name + " = " + currPlayer);
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<BrokenPart>() == true)
                parts.Add(transform.GetChild(i).GetComponent<BrokenPart>());
        }
        AITimer = Random.Range(AITimerRange.x, AITimerRange.y);
    }

    private void Update()
    {

        //Debug.Log(name + " = " + currPlayer);
        if (reset)
        {
            foreach (BrokenPart part in parts)
            {
                ChangePart(part, false);
            }
            reset = false;
        }
        AI();
    }

    private void AI()
    {
        //List<int> parts = new List<int>();
        if (!AIControl) return;
        if (!gameOver)
        {
            AITimer -= Time.deltaTime;
            if (AITimer >= 0) return;
            int partNum = Mathf.RoundToInt(Random.Range(0, parts.Count));
            if (parts.Count >= 1)
            {
                parts.Remove(parts[partNum]);
                ChangePart(parts[partNum], true);
                parts[partNum].broken = false;
                parts[partNum].health = parts[partNum].origHealth;

                currPlayer.mingamePts += Mathf.RoundToInt(Random.Range(3, 5));

                AITimer = Random.Range(AITimerRange.x, AITimerRange.y);
            }
            else
            {
                //Debug.Log(name + " = " + parts.Count);
                currPlayer.mingameWins += 10;
                currPlayer.SetPlace(1);
                manager.EndGame();
            }
        }
        else
        {
            currPlayer.SetPlace(parts.Count);
            AIControl = false;

        }
    }

    public void ChangePart(BrokenPart part, bool fix)
    {
        if (part.swapMesh)
        {
            ChangeMesh(fix ? part.toMesh : part.origMesh, part);
        }

        if (part.swapMaterial)
        {
            ChangeMaterial(fix ? part.toMaterial : part.origMaterial, part);
        }

        if (part.swapChildState)
        {
            ToggleChild(part);
        }

        if (part.enableSwapper)
        {
            if (fix)
            {
                EnableSwapper(part, true);
            }

            else
            {
                EnableSwapper(part, false);
                ChangeMaterial(part.origMaterial, part);
            }
        }
        if (fix)
        {
            part.transform.GetChild(0).GetComponent<ObjectSpewer>().go = true;
        }
        if (parts.Count <= 0)
        {
            manager.EndGame();
        }
    }

    private static void ChangeMesh(Mesh newMesh, BrokenPart target)
    {
        target.GetComponent<MeshFilter>().sharedMesh = newMesh;
    }

    private static void ChangeMaterial(Material newMaterial, BrokenPart target)
    {
        target.GetComponent<MeshRenderer>().sharedMaterial = newMaterial;
    }

    //private void EnableChild(BrokenPart target, bool enable)
    //{
    //    target.transform.GetChild(0).gameObject.SetActive(enable);
    //}

    private static void ToggleChild(BrokenPart target)
    {
        for (int i = 0; i < target.transform.childCount; i++)
        {
            target.transform.GetChild(i)
                .gameObject.SetActive(!target.transform.GetChild(i).gameObject.activeInHierarchy);
        }
    }

    private static void EnableSwapper(BrokenPart target, bool enable)
    {
        target.GetComponent<MaterialSwapper>().stop = !enable;
        target.GetComponent<MaterialSwapper>().reset = !enable;
    }
}