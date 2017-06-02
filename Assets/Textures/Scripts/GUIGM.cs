using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIGM : MonoBehaviour
{
    [SerializeField]
    Text pointGraphic;

    [SerializeField]
    Text overPoints;

    [SerializeField]
    GameObject gameOver;

    [SerializeField]
    float duration;

    int pointScore;

    int pointTotal;

    float wait;

    bool coroutineOver;

    // Update is called once per frame
    void Awake()
    {
        FindObjectOfType<PauseManager>().Reset();

        if (SceneManager.GetActiveScene().name /*Application.loadedLevelName*/ == "GUI - The Game_1")
        {
            pointTotal = 10;
            pointGraphic.text = "Score: " + pointTotal;
        }
    }

    void Update()
    {
        pointGraphic.text = "Score: " + pointTotal;
    }


    //void FixedUpdate ()
    //{
    //    if (pointScore > pointTotal && coroutineOver == true)
    //    {
    //        //wait = pointScore / pointTotal * duration; 

    //    }
    //}

    public void PointGain(int pointValue)
    {
        pointScore = pointValue + pointScore;
        Debug.Log(pointScore);
        StartCoroutine(CountTo(pointScore));
        //StartCoroutine(pointTick(wait));
    }

    IEnumerator CountTo(int target)
    {
        int start = pointTotal;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            pointTotal = (int)Mathf.Lerp(start, target, progress);
            //Debug.Log(pointTotal);
            yield return null;
        }
        pointTotal = target;
    }

    //IEnumerator pointTick(float wait)
    //{
    //    coroutineOver = false;
    //    yield return new WaitForSeconds(wait);
    //    Debug.Log(wait);
    //    if(pointScore > pointTotal)
    //    {
    //        pointTotal++;
    //    }
    //    pointGraphic.text = "Score: " + pointTotal;
    //    Debug.Log(pointTotal);
    //    coroutineOver = true;
    //}

    public void Gameover()
    {
        //Time.timeScale = 0;
        overPoints.text = "Score: " + pointScore; ;
        //Debug.Log("End");
        gameOver.SetActive(true);
    }
}
