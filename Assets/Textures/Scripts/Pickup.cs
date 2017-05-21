using UnityEngine;
using System.Collections;


public class Pickup : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject monster;

    [SerializeField]
    float pointAddition;

    [SerializeField]
    int damageValue;


    #endregion

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case ("Part"):
                    GM.instance.PartGet();
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject);
                    break;
                case ("Health"):
                    GM.instance.HealthGet();
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject);
                    break;
                case ("Damage"):
                    GM.instance.Damage(damageValue);
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject, 0.1f);
                    break;
                case ("Point"):
                    gameObject.GetComponent<AudioSource>().Play();
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject);
                    break;
                case ("Upgrade"):
                    GM.instance.Upgrade();
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject);
                    break;
                case ("Downgrade"):
                    GM.instance.Downgrade();
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject);
                    break;
                case ("Shield"):
                    GM.instance.Shield();
                    GM.instance.PointGet(pointAddition);
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
