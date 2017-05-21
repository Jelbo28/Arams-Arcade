using UnityEngine;
using System.Collections;

public class Perlin : MonoBehaviour
{
    [SerializeField]
    GameObject shaken;

    [SerializeField]
    float shakeAmmount;

    [SerializeField]
    GameObject Audio;

    [SerializeField]
    float shakeTimer;

    Vector2 shakePos;

	// Use this for initialization
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeObject(1);
        }

        if (shakeTimer >= 0)
        {
            shakePos = Random.insideUnitCircle * shakeAmmount;
            shaken.transform.position = new Vector2(transform.position.x + shakePos.x, transform.position.y + shakePos.y);
            shakeTimer -= Time.deltaTime;
        }
        if (shakeTimer <= 0)
        {
            Audio.SetActive(false);
        }
	}

    public void ShakeObject(float shakeDur)
    {
        if (shakeTimer <= 0)
        {
            shakeTimer = shakeDur;
            shakeAmmount = Random.Range(1, 7);
        }
    }
}
