using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{
    #region Variables

    [SerializeField]
    GameObject monster;
    #endregion

    void Awake()
    {
        Destroy(gameObject, 5f);
    }
}
