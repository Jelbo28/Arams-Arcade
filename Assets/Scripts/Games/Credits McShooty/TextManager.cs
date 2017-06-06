using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject[] creditComponents;
    [SerializeField] private float duration;
    private MinigameController minigameController;
    private int pointScore;
    private int pointTotal;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        minigameController = FindObjectOfType<MinigameController>();
        StartCoroutine(TextLoop());
        scoreText.text = "Data Pts: " + pointTotal;
    }

    private void Update()
    {
        scoreText.text = "Data Pts: " + pointTotal;
    }

    public void Score(Vector2 valueRange)
    {
        pointScore += Mathf.RoundToInt(Random.Range(valueRange.x, valueRange.y));
        StartCoroutine(CountTo(pointScore));
    }

    private IEnumerator TextLoop()
    {
        var i = 1;
        while (i < creditComponents.Length)
        {
            yield return new WaitForSeconds(5);

            creditComponents[i].SetActive(true);
            i++;
        }
        minigameController.displayManager.endGame = true;
    }

    private IEnumerator CountTo(int target)
    {
        var start = pointTotal;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            var progress = timer/duration;
            pointTotal = (int) Mathf.Lerp(start, target, progress);
            yield return null;
        }
        pointTotal = target;
        minigameController.thisPlayer.mingamePts = pointTotal;
    }
}