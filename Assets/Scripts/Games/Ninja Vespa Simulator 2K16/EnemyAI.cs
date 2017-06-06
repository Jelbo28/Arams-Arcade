using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    float distance = 75f;

    [SerializeField]
    Vector2 RayAngle = new Vector2(1, 1);

    [SerializeField]
    GameObject m_firePoint;

    private bool FiredRecently = false;

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, RayAngle, distance);

        Debug.DrawRay(transform.localPosition, RayAngle, Color.yellow);
        
		if (hit.collider.tag == "Player")
        {
			Debug.Log ("I fired a ray and see the player");
			if (FiredRecently == false)
            {
                GameObject obj = NewObjectPoolerScript.current.GetPooledObject();

                if (obj == null) return;



                obj.transform.position = m_firePoint.transform.position;
                obj.transform.rotation = m_firePoint.transform.rotation;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * 2, ForceMode2D.Impulse);

                FiredRecently = true;

                ResetingFire();
            }
            
        }
        
        Debug.Log(FiredRecently);
    }

    void ResetingFire()
    {
        StartCoroutine(ResetTheBool());
    }

    IEnumerator ResetTheBool()
    {
        yield return new WaitForSeconds(1.5f);

        FiredRecently = false;
    }
}
