using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    Text healthy;
    [SerializeField]
    public float health;
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    int splitting = 0;
    //[SerializeField]
    //string damagerTag;
    //[SerializeField]
    //float speed = 2f;
    [SerializeField]
    float flashTime = 0.2f;
    [SerializeField]
    GameObject blobPrefab;
    [SerializeField]
    public Transform[] blobSpawn;
    [SerializeField]
    int pointValue = 1;

    public float initialHealth;
    private bool player = false;
    private GameObject blob;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            player = true;
        }
        initialHealth = health;
    }

    void Update()
    {
        //Debug.Log(gettum);
        //if (gettum == true && go == true)
        //{
        //    //go = false;
        //    gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.position, speed * Time.deltaTime);
        //}
    }

    void CheckDead()
    {
        if (player)
        {
            healthy.text = "Health: " + health;
        }
        if (health <= 0)
        {
            if (splitting > 0)
            {
                for (int  i = 0; i < blobSpawn.Length; i++)
                {
                    blob = Instantiate(blobPrefab, blobSpawn[i].position, blobSpawn[i].rotation) as GameObject;
                }
            }
            Die();
        }

    }

    public void Attacked(float damage)
    {
        Debug.Log("Ahh");
        health -= damage;
        StartCoroutine(ColorFlash());
        CheckDead();
    }

    void Die()
    {
        if (player)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameObject.GetComponent<BlobController>().enemy.GetComponent<PlayerController>().Score(pointValue);
        }
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!player)
        {
            if (other.tag == "Sword")
            {
                health--;
            }
            else if (other.tag == "Projectile")
            {
                health -= 2;
            }
            
            CheckDead();
            if (gameObject.activeSelf == true)
            {
                StartCoroutine(ColorFlash());
            }
        }
        //if (other.tag == "Player")
        //{
        //    //target = other.GetComponent<Transform>();
        //    Debug.Log("Whyyyyyy");
        //    gettum = true;
        //    StartCoroutine(Move());
        //}
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        gettum = false;
    //        go = false;
    //    }
    //}

    IEnumerator ColorFlash()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(flashTime);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    //IEnumerator Move()
    //{
    //    while(gettum == true)
    //    {
    //        yield return new WaitForSeconds(1);
    //        float x = Random.Range(-3f, 3f);
    //        float y = Random.Range(-3f, 3f);
    //        Debug.Log("What???");
    //        target.position = new Vector3(x, y, 0);
    //        go = true;
    //    }
    //}
}
