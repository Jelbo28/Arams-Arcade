using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour {
    public Material deafultMaterial;
    public Material yourMaterial;
    // Use this for initialization

    void Start()
    {
        //defaultMaterial = GetComponent<SpriteRenderer>().material;
        deafultMaterial = new Material(Shader.Find("Sprites/Default"));
    }
    void ResetMaterial()
    {
        GetComponent<SpriteRenderer>().material = deafultMaterial;
    }
    void ChangeMaterial()
    {
        GetComponent<SpriteRenderer>().material = yourMaterial;
    }
}
