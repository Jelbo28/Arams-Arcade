using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpDisplayManager : MonoBehaviour {

    [HideInInspector]
    public Text mainText;


	// Use this for initialization
	void Start () {
        mainText = GetComponentInChildren<Text>();
        //Debug.Log(mainText.text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
