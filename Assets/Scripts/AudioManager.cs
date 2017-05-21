using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    //float waitBeforeClip;
    //[SerializeField]
    //public bool play = false;

    [SerializeField]
    List<AudioClip> bouncySounds;
    [SerializeField]
    List<AudioClip> bounceSounds;

    AudioSource AS;
    //private float initialValue;
    private int currClipNumber;
    private int clipNumber;

    // Use this for initialization
    void Awake()
    {
        //initialValue = waitBeforeClip;
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Debug.Log(AS.isPlaying);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlaySound();
        //}
        //waitBeforeClip -= Time.deltaTime;
        //if (waitBeforeClip <= 0f && play)
        //{
        //    PlaySound();
        //    waitBeforeClip = AS.clip.length;
        //}
    }

    public void PlaySound(bool bounce)
    {
        if (!bounce)
        {
            clipNumber = Mathf.RoundToInt(Random.Range(0f, bouncySounds.Count - 1));
            while (clipNumber == currClipNumber)
            {
                //Debug.Log("Joe");
                clipNumber = Mathf.RoundToInt(Random.Range(0f, bouncySounds.Count - 1));
            }

        }
        else
        {
            clipNumber = Mathf.RoundToInt(Random.Range(0f, bounceSounds.Count - 1));
            while (clipNumber == currClipNumber)
            {
                //Debug.Log("Joe");
                clipNumber = Mathf.RoundToInt(Random.Range(0f, bounceSounds.Count - 1));
            }
        }

        AS.Stop();
        AS.clip = (bounce) ?  bounceSounds[clipNumber] : bouncySounds[clipNumber];

        currClipNumber = clipNumber;
        AS.Play();
        if (!AS.isPlaying)
        {
            AS.UnPause();
        }
        //play = false;
    }

}

