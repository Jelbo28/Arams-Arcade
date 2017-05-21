using UnityEngine;
using System.Collections;

public class HittingBrother : MonoBehaviour 
{
	public BrotherHealth Brother;

	void Start ()
	{
		Brother = GameObject.FindGameObjectWithTag ("Brother").GetComponent<BrotherHealth> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Brother")
		{
			Brother.m_TimesHit = Brother.m_TimesHit + 1;

			Brother.OnHit ();

			this.gameObject.SetActive(false);
		}
	}
}
