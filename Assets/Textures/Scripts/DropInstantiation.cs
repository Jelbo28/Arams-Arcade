using UnityEngine;
using System.Collections;

public class DropInstantiation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject GM;

    [SerializeField]
    GameObject[] parts;
    [SerializeField]
    GameObject[] points;
    [SerializeField]
    GameObject powerUp;
    [SerializeField]
    GameObject powerDown;
    [SerializeField]
    GameObject health;
    [SerializeField]
    GameObject[] damage;
    [SerializeField]
    GameObject shield;


    [SerializeField]
    Animator monsterAnim;
    [SerializeField]
    GameObject spawnPoint;

    float randNum;
    int randPart;
    int randPoint;
    int randDamage;
    int chosenValue;
    #endregion

    void Awake()
    {
        InvokeRepeating("Spawn", 1.0f, 2f);
    }

    void Spawn()
    {
        gameObject.GetComponent<AudioSource>().Play();
        randNum = Random.Range(0f, 101f);
        if ((randNum >= 0) && (randNum <= 30))
        {
            randPart = Random.Range(0, parts.Length);
            Instantiate(parts[randPart], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 31) && (randNum <= 45))
        {
            randPoint = Random.Range(0, points.Length);
            Instantiate(points[randPoint], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 46) && (randNum <= 50))
        {
            Instantiate(powerUp, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        if ((randNum >= 51) && (randNum <= 60))
        {
            Instantiate(powerDown, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if ((randNum >= 61) && (randNum <= 70))
        {
            if (GM.GetComponent<GM>().healthyBot == false)
            {
                Instantiate(health, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
            else
            {
                Instantiate(damage[0], spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
        }
        if ((randNum >= 71) && (randNum <= 80))
        {
            if (GM.GetComponent<GM>().shield == false)
            {
                Instantiate(shield, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
            else
            {
                Instantiate(damage[0], spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
        }
        else if ((randNum >= 81) && (randNum <= 101))
        {
            randDamage = Random.Range(0, 101);
            if (randDamage <= 95)
            {
                chosenValue = 0;
            }
            else if (randDamage >= 95)
            {
                chosenValue = 1;
            }
            Instantiate(damage[chosenValue], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        monsterAnim.SetTrigger("ThrowGo");
    }
}
