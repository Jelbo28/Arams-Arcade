using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeToScene : MonoBehaviour {
    [SerializeField]
    string sceneTo = "";
    public void ToScene(string scene = "")
    {
        if (scene == "")
            scene = sceneTo;
        SceneManager.LoadScene(scene);
    }
}
