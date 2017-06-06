using UnityEngine;
using System.Collections;

public class ThrowingStars : MonoBehaviour {
    [SerializeField]
    GameObject NStar;
    [SerializeField]
    GameObject FirePoint;

    public Rigidbody2D rb;

	private bool FiredRecently;

	private Vector2 m_Direction = new Vector2 (1, 0);

	void Start()
	{
		FiredRecently = false;

		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
    {

		if (Input.GetKey (KeyCode.A)) 
		{
			m_Direction = Vector2.left;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			m_Direction = Vector2.right;
		}
        if (Input.GetKeyDown(KeyCode.E))
        {
			if (FiredRecently == false) 
			{
				GameObject obj = ThePoolerofObjects.current.GetPooledObject();

				if (obj == null) return;

				obj.transform.position = FirePoint.transform.position;
				obj.transform.rotation = FirePoint.transform.rotation;
				obj.SetActive(true);
				obj.GetComponent<Rigidbody2D> ().velocity = rb.velocity;

				Debug.Log (rb.velocity);

				obj.GetComponent<Rigidbody2D>().AddRelativeForce(m_Direction * 5, ForceMode2D.Impulse);

				FiredRecently = true;

				BoolResetting ();
			}
        }
	
	}

	void BoolResetting()
	{
		StartCoroutine (Bool ());
	}

	IEnumerator Bool()
	{
		yield return new WaitForSeconds (2f);

		FiredRecently = false;
	}
}
