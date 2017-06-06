using UnityEngine;
using System.Collections;

public class Cloudify : MonoBehaviour
{
    #region Variables
    int cloudSpeed;
    int Yskew;
    float currentYPosition;
    float currentXPosition;
    [SerializeField]
    float startY = 2;


    #endregion


    // Use this for initialization
    void Start ()
    {
        cloudSpeed = Random.Range(1, 3);
        Yskew = Random.Range(-1, 1);
        //Debug.Log(cloudSpeed);
        currentXPosition = transform.position.x;
        currentYPosition = transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentXPosition = currentXPosition + cloudSpeed * Time.deltaTime;
        if (currentXPosition >= 40)
        {
            currentXPosition = -40;
            currentYPosition = startY + Yskew;
        }
        transform.position = new Vector2(currentXPosition, currentYPosition);
	}
}
