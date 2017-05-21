using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;

    bool isDead;
    bool damaged;

	
	void Awake ()
    {
        currentHealth = startHealth;
	}
	

	public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

		Debug.Log (currentHealth);

        if(currentHealth <= 0 && !isDead)
        {
            Dead();
        }
	}
    public void Dead ()
    {
        isDead = true;
        //Application.LoadLevel(Application.loadedLevel);
		Debug.Log("Dis dude is dead yo");
		Debug.Break ();
    }
}
