using UnityEngine;
using System.Collections;

public class SpacePulse : MonoBehaviour
{

    void Update()
    {
        if (gameObject.GetComponent<RectTransform>().lossyScale != new Vector3 (0.5f, 0.5f, 0.5f))
        {
            iTween.ScaleTo(this.gameObject, iTween.Hash("scale", new Vector3(0.5f, 0.5f, 0.5f), "time", 1f, "easeType", iTween.EaseType.linear, "delay", 1.5f));
        }
    }

    public void Pulse()
    {
        iTween.ScaleFrom(this.gameObject, iTween.Hash("scale", new Vector3(0.8f, 0.8f, 0.8f),"time", 1f, "easeType", iTween.EaseType.linear));
    }
}
