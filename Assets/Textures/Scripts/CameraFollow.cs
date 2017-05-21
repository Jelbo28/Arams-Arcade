﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    [SerializeField]
    float m_speed = 0.1f;
    Camera mycam;

	// Use this for initialization
	void Start () {
        mycam = GetComponent<Camera>();
	
	}
	
	// Update is called once per frame
	void Update () {

        //mycam.orthographicSize = (Screen.height / 100f) / 4f;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3 (0, 0, -10);
        }
	
	}
}
