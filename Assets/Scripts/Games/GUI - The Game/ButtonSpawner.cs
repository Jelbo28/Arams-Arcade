using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField]
    Transform[] SpawnPoints;

    [SerializeField]
    float spawnTime = 1.5f;

    [SerializeField]
    GameObject[] Buttons;

    [SerializeField]
    int[] randValues;

    int spawnIndex;

    //float randX;
    //float randY;

    int q = 0;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnCoins", spawnTime, spawnTime);
        //Time.timeScale = 100;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnCoins()
    {
        //randX = Random.Range(-100, 100);
        //randY = Random.Range(-100, 100);
        
        float randRotationZ = Random.Range(-360, 360);
        Color butColor = new Color(Random.value, Random.value, Random.value);
        while (randValues.Contains(spawnIndex))
        {
            spawnIndex = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length));
        }
        q++;
        if (q >= 7)
        {
            q = 0;
            System.Array.Clear(randValues, 0, randValues.Length);
        }
        randValues[q] = spawnIndex;
        int buttonIndex = Mathf.RoundToInt(Random.Range(0f, Buttons.Length));
        GameObject go = Instantiate(Buttons[buttonIndex], /*new Vector3(randX, randY, 0)*/SpawnPoints[spawnIndex].position,SpawnPoints[spawnIndex].rotation) as GameObject;
        go.transform.SetParent(GameObject.Find("Container").transform);
        go.transform.localScale = new Vector3(2, 2, 1);
        go.transform.Rotate(0,0,randRotationZ);
        go.GetComponent<Image>().color = butColor;
    }
}
