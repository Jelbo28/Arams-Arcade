using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour {

    [SerializeField]
    AudioMixer masterMixer;
    private float origVol;
    public void SetSfxLevel(float sfxLevel)
    {
        masterMixer.SetFloat("sfxVol", sfxLevel);
    }

    public void SetMusicLevel(float musicLevel)
    {
        masterMixer.SetFloat("musicVol", musicLevel);
    }

    public void SetMasterLevel(float masterLevel)
    {
        masterMixer.SetFloat("masterVol", masterLevel);
    }

    public void Mute(bool mute)
    {
        if (mute)
        {
            masterMixer.GetFloat("masterVol", out origVol);
            masterMixer.SetFloat("masterVol", -80f);
        }
        else
        {
            masterMixer.SetFloat("masterVol", origVol);
        }
    }
}
