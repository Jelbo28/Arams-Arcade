using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletFireScript : MonoBehaviour {

	public float fireTime = .05f;
	public GameObject Marker;

	void Update () {

		if(Input.GetButtonDown("Fire2"))
		{
		//Invoke ("Fire", fireTime, fireTime);

			Fire();
		}
		if (Input.GetButtonDown ("Fire1")) 
		{
			Marker = GameObject.FindGameObjectWithTag("Marker");
			if(Marker == null) return;
			Marker.SetActive(false);
		}
	}

	void Fire () 
	{
		GameObject obj = NewObjectPoolerScript.current.GetPooledObject ();

				if (obj == null) return;

				obj.transform.position = transform.position;
				obj.transform.rotation = transform.rotation;
				obj.SetActive (true);
	}
}

