using UnityEngine;
using System.Collections;

public class NStarSpeed : MonoBehaviour {

    [SerializeField]
    GameObject NStar;

    public Rigidbody2D RB;
	
	void FixedUpdate ()
    {
	    if(Input.GetKeyDown(KeyCode.E))
        {
            RB.AddForce(Vector3.right * 800);
            StartCoroutine("Enable");
        }
	}
	
	
	IEnumerator Enable()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
	}
}
