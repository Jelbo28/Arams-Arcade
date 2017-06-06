using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


     public int startingHealth = 20;
     public int currentHealth;
     bool isDead;
 	
 	void Awake ()
     {
         currentHealth = startingHealth;
 	}
 	
 
 	public void TakeDamage (int Damage)
     {
          currentHealth -= Damage;
 
 	    if(isDead)
         {
             return;
         }
         if(currentHealth <= 0)
         {
             Death();
         }
 	}
     void Death()
     {
		this.gameObject.SetActive(false);
     }
}
