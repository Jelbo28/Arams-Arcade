using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatoe : MonoBehaviour {
            [SerializeField]
    public float turnSpeed = 30.0F;
    void Update()
    {
       transform.Rotate(0, turnSpeed * Time.deltaTime, 0, Space.Self);
    }
}
