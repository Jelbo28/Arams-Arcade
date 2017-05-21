using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressMeter : MonoBehaviour
{
    //[SerializeField]
    //Text TextIndicator;
    //[SerializeField]
    //Text TextLoading;
    [SerializeField]
    Image loadingBar;
    [SerializeField]
    float loadingTime;

    private float loadingTimer;
    private float toPercent;
    private float toLoad;
    public bool complete;

    [SerializeField]
    private Image[] images;


    void Start()
    {
        loadingTimer = 0;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    loadingTimer = 0;
        //}
        if (loadingTimer < loadingTime)
        {
            loadingTimer += Time.deltaTime;
            toPercent = loadingTimer / loadingTime * 100f;
            toLoad = toPercent / 100f;
            //TextIndicator.text = Mathf.Round(toPercent) + "%";
            loadingBar.fillAmount = toLoad;
        }
        else if (!complete)
        {

            //TextIndicator.text = "100%";
            //TextLoading.text = "Done!";
            loadingTime = 0f;

            for (int i = 0; i < images.Length; i++)
            {
                images[i].enabled = false;
                //Debug.Log(i);
            }
            complete = true;
        }




    }

    public void Activate(float loadTime)
    {
        loadingTime = loadTime;
        loadingTimer = 0f;
        complete = false;
    }

    public void Cancel()
    {
        //TextIndicator.text = "100%";
        //TextLoading.text = "Done!";
        loadingTime = 0f;
        complete = true;
    }
}
