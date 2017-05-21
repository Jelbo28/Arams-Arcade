using UnityEngine;
using System.Collections;

public class DoItMeme : MonoBehaviour
{
    [SerializeField]
    GameObject DoIt;

    public void Go()
    {
        GameObject go = Instantiate(DoIt, DoIt.transform.position, DoIt.transform.rotation) as GameObject;
        go.transform.SetParent(GameObject.Find("Effects").transform);
    }
}
