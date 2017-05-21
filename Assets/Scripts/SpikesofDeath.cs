using UnityEngine;
using System.Collections;

public class SpikesofDeath : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			//other.GetComponent<AnimationTransitions>().Gameover();
		}
	}
}
