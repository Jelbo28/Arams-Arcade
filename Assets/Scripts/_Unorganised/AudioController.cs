using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    AudioSource[] audios;

    [SerializeField]
    bool loop = false;

    #endregion

    public void AudioOne()
    {
        audios[0].Play();
    }

    public void AudioTwo()
    {
        audios[1].Play();
    }

    public void AudioThree()
    {
        if (loop == true)
        {
            audios[2].loop = true;
        }
        else
        {
            audios[2].loop = false;
        }
        audios[2].Play();
    }

    public void AudioFour()
    {
        audios[3].Play();
    }
}
