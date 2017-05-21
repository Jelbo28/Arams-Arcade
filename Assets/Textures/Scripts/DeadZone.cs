using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour 
{
	// public GM gameManager
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Ball")
		{
            BreakoutGM.instance.LoseLife();
            Destroy(col.gameObject);
		}
		// GameManager.LoseLife();
	}
}
