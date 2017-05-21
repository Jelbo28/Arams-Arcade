using UnityEngine;
using System.Collections;

public class BrotherHealth : MonoBehaviour 
{
	public int m_TimesHit;

	public BrotherMovement BrotherMove;

	void Start()
	{
		m_TimesHit = 0;
	}

	public void OnHit()
	{
		Debug.Log (m_TimesHit);

		//m_TimesHit = m_TimesHit + 1;

		if (m_TimesHit >= 10) 
		{
			Debug.Break ();
		}
		if (m_TimesHit >= 5) 
		{
			BrotherMove.m_Speed = 5;
		}
		if (m_TimesHit >= 8) 
		{
			BrotherMove.m_Speed = 7;
		}
	}
}
