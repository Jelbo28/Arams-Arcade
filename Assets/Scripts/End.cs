using UnityEngine;
using System.Collections;

public class End : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			//other.GetComponent<AnimationTransitions>().LoadFight();
		}
	}

}
