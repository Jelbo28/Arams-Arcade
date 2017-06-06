using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPart : MonoBehaviour {
    public float health;
    public float origHealth;
    public bool swapMesh;
    public bool swapMaterial;
    public bool swapChildState;
    public bool enableSwapper;
    public bool broken = true;

    public Mesh toMesh;
    public Material toMaterial;

    [HideInInspector]
    public Mesh origMesh;
    [HideInInspector]
    public Material origMaterial;

    void Start()
    {
        origMesh = GetComponent<MeshFilter>().sharedMesh;
        origMaterial = GetComponent<MeshRenderer>().sharedMaterial;
        origHealth = health;
    }
}
