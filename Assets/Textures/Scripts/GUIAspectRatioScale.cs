using UnityEngine;
using System.Collections;

public class GUIAspectRatioScale : MonoBehaviour
{
    [SerializeField]
    Vector2 scaleOnRatio1 = new Vector2(0.1f, 0.1f);

    Transform myTransform;
    float widthHeightRatio;

	// Use this for initialization
	void Start ()
    {
        myTransform = transform;
        SetScale();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetScale();
    }

    void SetScale()
    {
        widthHeightRatio = (float)Screen.width / Screen.height;
        myTransform.localScale = new Vector3(scaleOnRatio1.x, widthHeightRatio * scaleOnRatio1.y, 1f);
    }
}
