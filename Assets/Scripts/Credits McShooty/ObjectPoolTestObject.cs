using UnityEngine;

public class ObjectPoolTestObject : PoolObject
{
    [SerializeField]
    float speed;

    [SerializeField]
    GameObject explosion;

    void Update()
    {
        //transform.Translate(new Vector3(1, 1, 1) * speed * Time.smoothDeltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(0, 0, speed * Time.deltaTime * 5);
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    //public override void OnObjectReuse()
    //{

    //}
}
