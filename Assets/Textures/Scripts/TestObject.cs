using UnityEngine;

public class TestObject : PoolObject
{
    [SerializeField]
    float speed;

    void Update()
    {
        //transform.Translate(new Vector3(1, 1, 1) * speed * Time.smoothDeltaTime);
        transform.position += transform.right * Time.deltaTime * speed;
    }

    public override void OnObjectReuse()
    {

    }
}
