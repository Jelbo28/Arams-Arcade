using UnityEngine;

public class PeriodicElement : MonoBehaviour
{
    private Animator anim;
    private ElementChase elementChase;
    [SerializeField] private int elementNumber;
    private ElementSpawner elementSpawner;
    [SerializeField] private float force;
    [SerializeField] private Vector2 forceRange;
    private float newRot;
    private Rigidbody2D rb;
    [SerializeField] private float rotRange;
    [SerializeField] private string thisElement;
private float timer;
    [SerializeField] private Vector2 timerRange;
    // Use this for initialization
    private void Awake()
    {
        name = thisElement;
        //Debug.Log("hi guys");
        elementSpawner = FindObjectOfType<ElementSpawner>();
        timer = Random.Range(timerRange.x, timerRange.y);
        rb = GetComponent<Rigidbody2D>();
        //GetComponent<BoxCollider2D>().enabled = true;
        //GetComponent<SpriteRenderer>().sortingOrder = 1;
        elementChase = FindObjectOfType<ElementChase>();
        anim = GetComponent<Animator>();
        newRot = Random.Range(-rotRange, rotRange);

        //timer = Random.Range(timerRange.x, timerRange.y);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 1)
            {
                transform.Rotate(Vector3.forward*newRot*Time.deltaTime);
            }
        }
        else if (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) < .5f)
        {
            newRot = Random.Range(-rotRange, rotRange);
            force = Random.Range(forceRange.x, forceRange.y);
            rb.AddForce(transform.up*force*Time.deltaTime);
            timer = Random.Range(timerRange.x, timerRange.y);
        }
        else
        {
            rb.velocity *= Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("eddy");
        //GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<SpriteRenderer>().sortingOrder = 4;
        elementChase.AddElement(name);
        anim.SetTrigger("Poof");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("pizza");
        if (other.tag == "Player")
            Respawn();
    }

    public void Respawn()
    {
       // Debug.Log("pizza");

        elementSpawner.Respawn(gameObject);
        GetComponent<BoxCollider2D>().isTrigger = false;
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        //gameObject.SetActive(false);
    }
}