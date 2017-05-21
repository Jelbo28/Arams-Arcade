using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ElementChase : MonoBehaviour
{
    private int currLevel;
    [SerializeField] private Element[] elements;
    [SerializeField] private Level[] levels;
    private MinigameController minigameController;
    private Transform MoleculeModel;
    [SerializeField] private Text molText;
    [SerializeField] private int playerScore;
    [SerializeField] private int remainingElements;
    private PlayerInfo[] players;
    private PlayerInfo thisPlayer;
    private void Start()
    {
        players = FindObjectOfType<ScoreManager>().GetComponentsInChildren<PlayerInfo>();
        foreach (PlayerInfo player in players)
        {
            if (player.thisUser == true)
                thisPlayer = player;
        }
        molText = GameObject.Find("MolText").GetComponent<Text>();
        minigameController = FindObjectOfType<MinigameController>();
        MoleculeModel = GameObject.Find("3D Molecule").transform;
        StartCoroutine(StartGame());
    }

    private void CheckElements()
    {
        foreach (Element element in elements)
        {
            if (element.count != element.prevCount)
            {
                if (element.count > 0)
                {
                    if (!element.remaining)
                    {
                        element.remaining = true;
                        remainingElements++;
                    }

                    element.uiDisp.transform.GetChild(0).GetComponent<Text>().text = element.count.ToString();
                    element.uiDisp.SetActive(true);
                }
                else
                {
                    element.remaining = false;
                    remainingElements--;
                    element.uiDisp.transform.GetChild(0).GetComponent<Text>().text = "0";
                    element.uiDisp.SetActive(false);
                    StartCoroutine(ChangeLevel());
                }
                element.prevCount = element.count;
            }
        }
    }

    public void AddElement(string elementName, int howMany = 1, bool setNew = false)
    {
        foreach (Element element in elements)
        {
            if (element.name == elementName)
            {
                if (!setNew)
                {
                    if (element.remaining)
                    {
                        element.count--;
                        playerScore++;
                        minigameController.AddPoints(1);
                    }
                    else
                    {
                        playerScore--;
                        minigameController.AddPoints(-1);
                        break;
                    }
                }
                else
                {
                    element.count += howMany;
                }
            }
        }
        CheckElements();
    }

    public void BeginLevel()
    {
        molText.text = levels[currLevel].molName;
        molText.GetComponent<Animator>().SetTrigger("SetName");
        MoleculeModel.GetChild(0).GetComponent<Animator>().SetTrigger("Enter");
        if (currLevel > 0)
        {
            MoleculeModel.GetChild(0).GetChild(currLevel - 1).gameObject.SetActive(false);
        }

        MoleculeModel.GetChild(0).GetChild(currLevel).gameObject.SetActive(true);
        MoleculeModel.GetChild(0).GetComponent<Animator>().SetInteger("MoveType", levels[currLevel].molMoveType);
        for (int i = 0; i < levels[currLevel].elementsUsed.Length; i++)
        {
            AddElement(levels[currLevel].elementsUsed[i], levels[currLevel].howMany[i], true);
        }
        currLevel++;
    }

    private IEnumerator ChangeLevel()
    {
        if (remainingElements <= 0)
        {
            MoleculeModel.GetChild(0).GetComponent<Animator>().SetTrigger("Exit");
            if (currLevel < levels.Length)
            {
                yield return new WaitForSeconds(2f);
                BeginLevel();

            }
            else
            {
                thisPlayer.SetPlace(1);
                thisPlayer.mingameWins += 10;
                //yield return new WaitForSeconds(1f);
                minigameController.displayManager.endGame = true;
            }
        }

    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4f);
        BeginLevel();
    }

    [Serializable]
    public class Element
    {
        public int count;
        public string name;
        public int prevCount;
        public bool remaining;
        public GameObject uiDisp;
    }

    [Serializable]
    public class Level
    {
        public string[] elementsUsed;
        public int[] howMany;
        public int molMoveType;
        public string molName;
    }
}