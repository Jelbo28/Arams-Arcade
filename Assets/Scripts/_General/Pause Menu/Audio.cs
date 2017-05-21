using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour
{
    [SerializeField]
    AudioSource[] sounds;

    public void BallBeat(float jumpVelocity)
    {
        sounds[0].pitch = ((jumpVelocity * 0.1f) + 1f);
        if (jumpVelocity == 0)
        {
            sounds[0].pitch = 1f;
        }
        Debug.Log(jumpVelocity + ", " + sounds[0].pitch);
        sounds[0].Play();
    }

    public void CoinBlip()
    {
        sounds[1].Play();
    }

}
