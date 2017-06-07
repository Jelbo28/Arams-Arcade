using UnityEngine;
using System.Collections;

public class EnemyNinjaStars : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//Destroy (other.gameObject);
			//other.GetComponent<PlayerHealthBar>().Damage();
			Destroy (this.gameObject);
		}
	}
}
