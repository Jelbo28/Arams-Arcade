using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    
	public int Damage = Random.Range(1, 20);

	[SerializeField]
    PlayerHealth playerHealth;
	[SerializeField]
	EnemyHealth enemyHealth;

	void OnTriggerEnter2D (Collider2D other)
    {
		if (other.tag == "Enemy") 
		{

			Damage = Random.Range (1, 20);

			this.gameObject.SetActive (false);

			Attack ();
		}
        
    }
	public void Attack()
    {    
            enemyHealth.TakeDamage(Damage);
    }
}
