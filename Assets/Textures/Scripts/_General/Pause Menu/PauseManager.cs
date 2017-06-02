using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

    [SerializeField]
    AudioMixerSnapshot paused;
    [SerializeField]
    AudioMixerSnapshot unpaused;

    private Canvas canvas;
    [SerializeField] private bool cursorOnStart = false;
    [SerializeField]
    private bool cursorToggle = false;

    private bool reset = false;

    public static PauseManager instance = null;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        reset = cursorOnStart;

    }

    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        

        canvas = GetComponent<Canvas>();           
    }

    // Update is called once per frame
    void Update () {
        if (reset)
        {
            Reset();
            reset = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    void Pause()
    {
        canvas.enabled = !canvas.enabled;
        if (cursorToggle)
        {
            Cursor.visible = Cursor.visible != true;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }

        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass();
    }

    public void Reset()
    {
        canvas.enabled = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }
        else
        {
            unpaused.TransitionTo(.01f);
        }
    }

    public void BackToMenu()
    {
        reset = true;
        GetComponent<SceneChanger>().LoadSceneByName("Level_Main");
    }

    void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
