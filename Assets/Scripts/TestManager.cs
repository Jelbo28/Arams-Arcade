using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    GameObject spawn;
    [SerializeField]
    AudioSource laser;

    void Start()
    {
        PoolManager.instance.CreatePool(prefab, 3);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.instance.ReuseObject(prefab, spawn.transform.position, spawn.transform.rotation);
            laser.Play();
        }

    }
}
