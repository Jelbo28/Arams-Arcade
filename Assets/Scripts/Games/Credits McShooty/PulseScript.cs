using UnityEngine;
using System.Collections;

public class PulseScript : MonoBehaviour
{
    bool scaleBack = true;

    void Update()
    {
        if (scaleBack)
        {
            iTween.ScaleTo(this.gameObject, new Vector3(0.5f, 0.5f, 0f), 1f);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Aram is amazing.");

            Pulse();

        }
    }
    public void Pulse()
    {
        PulseLock();
            iTween.ScaleFrom(this.gameObject, new Vector3(1f, 1f, 0f), 1.5f);
    }

    IEnumerator PulseLock()
    {
        scaleBack = false;
        yield return new WaitForSeconds(1.5f);
        scaleBack = true;
    }
}
