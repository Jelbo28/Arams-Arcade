using UnityEngine;
using System.Collections;

public class PartsSpawn : MonoBehaviour {

    // Serialized variables

    [SerializeField] GameObject[] parts;
    [SerializeField] float m_ForceX;

    // public variables

    public int count;
    public bool achoo;

    // private variables

    Animator monAnim;
    GameObject monster;
    EnemyActions direction;
    ConstantForce2D toss;

    // private methods

    void Awake()
    {
        monster = GameObject.Find("Monster");
        direction = monster.GetComponent<EnemyActions>();
        InvokeRepeating("Spawn", 1.0f, 2.0f);
        achoo = false;
        monAnim = monster.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        foreach (GameObject part in parts)
        {
            toss = part.GetComponent<ConstantForce2D>();
        }

        if (count > 3)
        {
            CancelInvoke();
        }

        if (direction.yes)
        {
            Fall(m_ForceX);
        }
        else if (!direction.yes)
        {
            Fall(-m_ForceX);
        }

    }

    void Spawn()
    {
        int i = Random.Range(0, parts.Length - 1);

        GameObject part = parts[i];

        Instantiate(part, monster.transform.position + new Vector3 (0f, -2f, 0f), new Quaternion (0f, 0f, 0f, 0f));
        count++;
    }

    void Fall (float x)
    {
        toss.relativeForce = new Vector2(x, 0);
        StartCoroutine(AttackAnim());
    }

    // IEnumerators

    IEnumerator AttackAnim()
    {
        monAnim.SetTrigger("ThrowGo");
        yield return new WaitForSeconds(3.0f);
        monAnim.SetBool("Throw", false);
    }
}
