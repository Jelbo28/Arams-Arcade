using UnityEngine;

public class DestroyWithSword : MonoBehaviour
{
    [SerializeField]
    Sprite[] state;
    [SerializeField]
    GameObject[] spawnObject;
    [SerializeField]
    Transform spawnLocation;
    private SpriteRenderer playerRender;
    private GameObject spawnThing;
	// Use this for initialization
	void Start ()
    {
        playerRender = GetComponent<SpriteRenderer>();
        playerRender.sprite = state[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword" || other.tag == "Projectile")
        {
            playerRender.sprite = state[1];
            int randObj = Random.Range(0, spawnObject.Length - 1);
            spawnThing = Instantiate(spawnObject[randObj], spawnLocation.transform.position, spawnLocation.transform.rotation) as GameObject;
            GetComponent<BoxCollider2D>().enabled = false;
            //switch (randObj)
            //{
            //    case 0:
            //        break;
            //    case 1:
            //        //spawnRuby
            //        break;
            //    case 2:
            //        //spawnRuby
            //        break;
            //    case 3:
            //        //spawnRuby
            //        break;
            //    default:
            //        break;
            //}
            //other.gameObject.GetComponentInParent<Damager>().Attacked(-1f);
        }
    }
}
