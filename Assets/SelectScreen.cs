using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectScreen : MonoBehaviour
{
    //[Range (0, 2)]
    //int selX;
    //[Range (0, 1)]
    //int selY;
    //The numerical ID of the player.
    [SerializeField]
    int PlayerNumber;
    //Vector3 coordinates;                               
    float speed = 1000.0f;

    //[SerializeField]
    //Image selectHighlight;
    [SerializeField]
    GameObject charDisplay;

    Vector3 coordinates;
    [SerializeField]
    KeyCode go;
    string selection;
    int selectionNum;
    //Movement variables
    public float horizontal;
    public float vertical;
    bool select = true;

    void Start()
    {
        coordinates = GetComponent<RectTransform>().anchoredPosition;
        //charDisplay = GameObject.Find("CharacterDisplay" + PlayerNumber.ToString()).GetComponent<Animator>();
    }
    void Update()
    {
        if (select)
        {
            MoveCursor();
            CheckChar(coordinates);
        }

        if (Input.GetKeyDown(go) && select)
        {
            //Debug.Log("poop");
            GM.instance.playerSelect[PlayerNumber - 1] = selection;
            select = false;
            GM.instance.SelectCharacter();
        }
    }

    void MoveCursor()
    {
        Vector3 position = GetComponent<RectTransform>().anchoredPosition;
        //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        horizontal = Input.GetAxis("Horizontal" + PlayerNumber.ToString());
        vertical = Input.GetAxis("Vertical" + PlayerNumber.ToString());


        if (horizontal < 0 && position == coordinates)
        {
            coordinates += new Vector3(-230, 0, 0);
        }
        if (horizontal > 0 && position == coordinates)
        {
            coordinates += new Vector3(230, 0, 0);
        }
        if (vertical > 0 && position == coordinates)
        {
            coordinates += new Vector3(0, 230, 0);
        }
        if (vertical < 0 && position == coordinates)
        {
            coordinates += new Vector3(0, -230, 0);
        }
        coordinates.x = Mathf.Clamp(coordinates.x, -115, 115);
        //coordinates.x *= 115;
        coordinates.y = Mathf.Clamp(coordinates.y, -217, 243);
        //coordinates.y *= 230;
        //position = coordinates;
        GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(position, coordinates, speed * Time.deltaTime);
        // Debug.Log(coordinates);
    }

    void CheckChar(Vector3 position)
    {
        if (position == new Vector3 (-115, 243, 0))
        {
            selection = "Kenny";
            selectionNum = 5;
        }
        if (position == new Vector3(115, 243, 0))
        {
            selection = "Richard Hitson";
            selectionNum = 1;
        }
        if (position == new Vector3(-115, 13, 0))
        {
            selection = "Tom Whack";
            selectionNum = 4;
        }
        if (position == new Vector3(115, 13, 0))
        {
            selection = "Karate Chef";
            selectionNum = 0;
        }
        if (position == new Vector3(-115, -217, 0))
        {
            selection = "Track Star";
            selectionNum = 2;
        }
        if (position == new Vector3(115, -217, 0))
        {
            selection = "Mooman";
            selectionNum = 3;
        }
        charDisplay.GetComponent<Animator>().SetInteger("charNumber", selectionNum);
        charDisplay.GetComponentInChildren<Text>().text = selection;

    }
}
