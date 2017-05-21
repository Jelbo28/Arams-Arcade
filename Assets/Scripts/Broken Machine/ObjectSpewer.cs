using UnityEngine;

public class ObjectSpewer : MonoBehaviour
{
    [SerializeField] private float forceStrength;
    public bool go;
    private int randTransform;
    [SerializeField] private Transform[] spawnAreas;
    [SerializeField] private float spawnRange;
    [SerializeField] private Vector2 spewAmmountRange;
    private GameObject tempSpew;
    private Rigidbody tempSpewRB;
    [SerializeField] private GameObject toSpew;

    private void Start()
    {
        spawnAreas = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if ( /*Input.GetKeyDown(KeyCode.Space)*/go)
        {
            for (var j = 0; j < spawnAreas.Length; j++)
            {
                var rand = Mathf.RoundToInt(Random.Range(spewAmmountRange.x, spewAmmountRange.y));

                for (var i = 0; i < rand; i++)
                {
                    tempSpew = Instantiate(toSpew, spawnAreas[j].position + (Random.insideUnitSphere*spawnRange),
                        Quaternion.LookRotation(Vector3.forward));
                    tempSpew.transform.SetParent(GameObject.Find("Data Points").transform);
                    tempSpewRB = tempSpew.GetComponent<Rigidbody>();
                    tempSpewRB.velocity = (Vector3.forward*forceStrength);
                }
            }
            go = false;
        }
    }
}