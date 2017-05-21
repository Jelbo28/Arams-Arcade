using UnityEngine;

public class CreditsText : MonoBehaviour
{
    [SerializeField] private Vector2 pointRange;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("woowie");
        if (other.gameObject.tag == "Laser")
        {
            //Debug.Log("bobert");
            GetComponentInParent<TextManager>().Score(pointRange);
            other.gameObject.GetComponent<ObjectPoolTestObject>().Explode();
            Destroy(gameObject);
        }
    }
}