using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

//    public float timeBetweenAttacks = 0.5f;
//    public int attackDamage = Random.Range(1, 50);
//
//
//    GameObject player;
//    PlayerHealth playerHealth;
//    EnemyHealth enemyHealth;
//    bool playerInRange;
//    float timer;
//
//	void Awake ()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");
//        playerHealth = player.GetComponent<PlayerHealth>();
//        enemyHealth = GetComponent<EnemyHealth>(); 
//	}
//	
//	
//	void OnTriggerEnter2D (Collider2D other)
//    {
//	    if(other.gameObject == player)
//        {
//            playerInRange = true;
//        }
//	}
//
//    void OnTriggerExit2D (Collider2D other)
//    {
//        if(other.gameObject == player)
//        {
//            playerInRange = false;
//        }
//    }
//
//    void Update()
//    {
//        timer += Time.deltaTime;
//
//        if(timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0)
//        {
//            Attack();
//        }
//    }
//
//    void Attack()
//    {
//        timer = 0f;
//
//        if(playerHealth.currentHealth > 0)
//        {
//            playerHealth.TakeDamage(attackDamage);
//        }
//    }
}
