using UnityEngine;
using System.Collections;

public class SortingLayerExposer : MonoBehaviour
{
    [SerializeField]
    string SortingLayerName = "Default";
    [SerializeField]
    int SortingOrder;

    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
        gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;
    }
}
