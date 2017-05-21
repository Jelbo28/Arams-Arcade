using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheForce : MonoBehaviour {
    [SerializeField]
    string highlightName;

    [SerializeField]
    float timer = 0.005f;

    private Collider target;
	void Start()
    {
        target = GetComponent<Collider>();
        target.enabled = false;
        name = highlightName;
    }
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            target.enabled = true;

        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
