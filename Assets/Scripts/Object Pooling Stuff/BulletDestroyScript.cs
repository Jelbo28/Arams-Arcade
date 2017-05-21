using UnityEngine;
using System.Collections;

public class BulletDestroyScript : MonoBehaviour {

	void OnEnable () 
	{
		Invoke ("Destroy",5f);
	}
	void Destroy()
	{
		gameObject.SetActive (false);
	}
	void OnDisable()
	{
		CancelInvoke ();
	}
}
