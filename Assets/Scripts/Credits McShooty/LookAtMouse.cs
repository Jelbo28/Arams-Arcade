using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    //   private Transform target;
    //   private Vector3 relativePosition;
    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {
    //       relativePosition = Camera.main.ViewportToWorldPoint(Input.mousePosition) - transform.position;
    //       transform.rotation = Quaternion.LookRotation(relativePosition);
    //}

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                            mouse.x,
                                                            mouse.y,
                                                            10000));
        Vector3 forward = mouseWorld - transform.position;
        transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }

}
