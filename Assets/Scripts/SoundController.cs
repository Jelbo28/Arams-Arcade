using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    AudioSource[] sounds;
    public AudioSource engine;
    public AudioSource honk;
	public AudioSource angry;
	public AudioSource intrigued;
	public AudioSource summon;

    void start()
    {
		/*
		sounds = GetComponents<AudioSource>();
		engine = sounds[0];
		honk = sounds[1];
		*/
    }

    public void CutAudio()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = false;
    }

    public void Honk()
    {
        honk.Play();
    }

	public void Angry()
	{
		angry.Play();
	}

	public void Intrigued()
	{
		intrigued.Play();
	}

	public void StopBro()
	{
		angry.enabled = false;
		intrigued.enabled = false;
	}

	public void Summon()
	{
		summon.Play ();
	}
}
