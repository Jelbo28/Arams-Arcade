using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    //public int MinX = 0;
    //public int MaxX = 10;
    //public int MinY = 0;
    //public int MaxY = 10;
    public int[] objectAmmount;
    //Private
    //private GameObject instantObject;

    private PoolManager poolManager;
    //Public
    //public GameObject area;
    [SerializeField] private Collider2D spawnColl;
    public GameObject[] spawnObject;
    private GameObject toCreate;

    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
        //Debug.Log("Spawn");
        for (var i = 0; i < spawnObject.Length; i++)
        {
            PoolManager.instance.CreatePool(spawnObject[i], objectAmmount[i]);
            for (var j = 0; j < objectAmmount[i]; j++)
            {
                poolManager.ReuseObject(spawnObject[i], PointInArea(), Quaternion.identity);
                //spawnObject[i].transform.position = PointInArea();
                //spawnObject[i].SetActive(true);
            }

            //spawnObject[i].name = spawnObject[i].name;
            //spawnObject[i.transform.SetParent(GameObject.Find("ElementChase").transform.GetChild(0));
        }
    }

    public Vector2 PointInArea()
    {
        var bounds = spawnColl.bounds;
        Vector2 center = bounds.center;

        float x = 0;
        float y = 0;
        var attempt = 0;
        do
        {
            x = Random.Range(center.x - bounds.extents.x, center.x + bounds.extents.x);
            y = Random.Range(center.y - bounds.extents.y, center.y + bounds.extents.y);
            attempt++;
        } while (!GetComponent<CircleCollider2D>().OverlapPoint(new Vector2(x, y)) && attempt <= 100);


        return new Vector2(x, y);
    }

    public void Respawn(GameObject toReuse)
    {
        //toReuse.SetActive(false);
        toReuse.transform.position = PointInArea();
        //spawnObject[elementNum].SetActive(true);
    }
}