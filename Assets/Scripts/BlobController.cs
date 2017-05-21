using UnityEngine;

public class BlobController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float timeToMove;
    [SerializeField]
    float timeToAttack;
    [SerializeField]
    float timeBetweenMove;
    [SerializeField]
    Color blobColor;
    [SerializeField]
    float moveRange;
    [SerializeField]
    float damageInflicted = 1;
    [SerializeField]
    float attackRange = 1.5f;
    [SerializeField]
    float view = 10f;
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    bool waterBlob = false;


    private Rigidbody2D thisRigidbody;
    private bool isMoving;
    private bool attacking;
    private bool collision = false;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    private Vector3 otherMoveDirection;
    private Collider2D attackCollider;
    private float timeBetweenAttackCounter;
    private GameObject ProjectileGO;
    public GameObject enemy;
    private Transform projectile;
    private Vector3 moveRotation;
    private Animator bossFade;


    void Start ()
    {
        bossFade = GameObject.FindWithTag("Fader").GetComponent<Animator>();
        enemy = GameObject.FindWithTag("Player");
        thisRigidbody = GetComponent<Rigidbody2D>();
        attackCollider = GetComponentInChildren<CircleCollider2D>();
        timeBetweenAttackCounter = timeToAttack;
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
	}

    void Update()
    {
        GetComponent<SpriteRenderer>().color = blobColor;
        timeBetweenAttackCounter -= Time.deltaTime;
        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            thisRigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                isMoving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            thisRigidbody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                isMoving = true;
                timeToMoveCounter = timeToMove;

                if (collision)
                {
                    collision = false;
                    otherMoveDirection = moveDirection - moveDirection * 2;
                    moveDirection = otherMoveDirection;
                }
                else
                {
                    moveDirection = new Vector3(Random.Range(-moveRange, moveRange) * moveSpeed, Random.Range(-moveRange, moveRange) * moveSpeed, 0f);
                }
            }
        }

        view = Vector3.Distance(enemy.transform.position, transform.position);
        //Debug.Log(view);
        if (timeBetweenAttackCounter < 0f && view <= 10f)
        {
            if (view <= attackRange)
            {
                enemy.GetComponent<Damager>().Attacked(damageInflicted);
            }
            //Debug.Log("Imma get ya!");
            if (gameObject.name == "Shadow Blob")
            {
                bossFade.SetBool("GO", true);
            }
            moveDirection = (enemy.transform.position - transform.position) * 1 / view;
            if (waterBlob == true)
            {
                moveRotation = enemy.transform.position - transform.position;
                float angle = Mathf.Atan2(-moveRotation.y, -moveRotation.x) * Mathf.Rad2Deg;
                //moveRotation.z = 0;
                ProjectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
            }
            timeBetweenAttackCounter = timeToAttack;
        }
    }

   void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    isMoving = false;
        //}
            collision = true; 
    }
}
