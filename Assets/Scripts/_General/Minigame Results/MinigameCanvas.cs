using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MinigameCanvas : MonoBehaviour
{
    private Text titleText;
    private Text minigameInfoText;
    private SceneChanger sceneChanger;
    void Start ()
	{
	    titleText = GetComponent<Text>();
        minigameInfoText = transform.GetChild(1).GetComponent<Text>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        titleText.text = sceneChanger.currentMinigame.minigameName;
        minigameInfoText.text = sceneChanger.currentMinigame.gameInfo;
    }
}
