using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region Variables

    [SerializeField]
    GameObject monster;

    [SerializeField]
    GameObject movingParts;

    [SerializeField]
    Text overParts;

    [SerializeField]
    Text overPoints;

    [SerializeField]
    Text overPoints2;

    [SerializeField]
    GameObject gameover;

    [SerializeField]
    GameObject win;

    [SerializeField]
    GameObject mainOverlay;

    [SerializeField]
    GameObject shieldObject;

    [SerializeField]
    Animator damageAnim;

    [SerializeField]
    AudioSource shieldDown;

    [SerializeField]
    AudioSource shieldUp;

    [SerializeField]
    AudioSource damage;

    [SerializeField]
    AudioSource upgrade;

    [SerializeField]
    AudioSource downgrade;

    [SerializeField]
    AudioSource healthSound;

    [SerializeField]
    AudioSource partGet;

    [SerializeField]
    AudioSource retry;

    [SerializeField]
    GameObject paddle;

    [SerializeField]
    Text parts;

    [SerializeField]
    Image health;

    [SerializeField]
    Sprite healthFull;

    [SerializeField]
    Sprite healthTwo;

    [SerializeField]
    Sprite healthOne;

    [SerializeField]
    Sprite healthZed;

    [SerializeField]
    int healthNumber = 3;

    [SerializeField]
    Text score;

    [SerializeField]
    float scoreNumber = 0;

    int partNumber = 0;

    [SerializeField]
    int totalParts = 15;

    float randomPitch;
    public bool shield = false;
    public bool healthyBot = true;

    public static GM instance = null;
    #endregion
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void PartGet()
    {
        randomPitch = Random.Range(0.8f, 1.2f);
        partGet.pitch = randomPitch;
        partGet.Play();
        partNumber++;
        parts.text = "Parts: " + partNumber + "/" + totalParts;
        overParts.text = "Parts: " + partNumber + "/" + totalParts;
        CheckWin();
    }

    public void PointGet(float pointAddition)
    {
        scoreNumber = scoreNumber + pointAddition;
        score.text = "Score: " + scoreNumber;
        overPoints.text = "Score: " + scoreNumber;
        overPoints2.text = "Score: " + scoreNumber;
    }

    public void HealthGet()
    {
        healthSound.Play();
        healthNumber++;
        if (healthNumber >= 3)
        {
            healthNumber = 3;
        }
        if (healthNumber <= 0)
        {
            healthNumber = 0;
        }
        HealthUpdate();
    }

    public void Damage(int damageValue)
    {
        if (!shield)
        {
            damage.Play();
            healthNumber = healthNumber - damageValue;
            if (healthNumber >= 3)
            {
                healthNumber = 3;
            }
            if (healthNumber <= 0)
            {
                healthNumber = 0;
            }
            damageAnim.SetBool("Hit", true);
            HealthUpdate();
        }
        if (shield)
        {
            ShieldDisable();
        }
    }

    public void Upgrade()
    {
        upgrade.Play();
        //paddle.GetComponent<Paddle>().Resize(2f);
        paddle.GetComponent<Paddle>().Grow();
        scoreNumber = scoreNumber + 10;
        score.text = "Score: " + scoreNumber;
        //Debug.Log("Upgrade");
    }

    public void Shield()
    {
        ShieldEnable();
    }

    public void Downgrade()
    {
        if (!shield)
        {
            downgrade.Play();
            paddle.GetComponent<Paddle>().Shrink();
            scoreNumber = scoreNumber - 10;
            score.text = "Score: " + scoreNumber;
            //Debug.Log("Downgrade");
        }
        if (shield)
        {
            ShieldDisable();
        }
    }


    void CheckWin()
    {
        if (partNumber >= totalParts)
        {
            partNumber = totalParts;
            parts.text = "Parts: " + partNumber + "/" + totalParts;
            overParts.text = "Parts: " + partNumber + "/" + totalParts;
            Win();
            //Debug.Log("Win");
        }
    }

    void HealthUpdate()
    {
        switch (healthNumber)
        {
            case (0):
                //damage.pitch = 1.2f;
                overParts.text = parts.text;
                overPoints.text = score.text;
                healthyBot = false;
                GameOver();
                break;
            case (1):
                health.GetComponent<Image>().sprite = healthOne;
                healthyBot = false;
                //damage.pitch =  0.9f;
                break;
            case (2):
                health.GetComponent<Image>().sprite = healthTwo;
                healthyBot = false;
                //damage.pitch = 1.1f;
                break;
            case (3):
                health.GetComponent<Image>().sprite = healthFull;
                healthyBot = true;
                //damage.pitch = 1f;
                break;
        }       
    }

    void ShieldEnable()
    {
        shieldUp.Play();
        shield = true;
        shieldObject.SetActive(true);
    }

    void ShieldDisable()
    {
        shieldDown.Play();
        shieldObject.SetActive(false);
        shield = false;
    }

    void GameOver()
    {
        health.GetComponent<Image>().sprite = healthZed;
        mainOverlay.SetActive(false);
        gameover.SetActive(true);
        monster.GetComponent<DropInstantiation>().CancelInvoke();
        Stop();
    }

    void Win()
    {
        mainOverlay.SetActive(false);
        win.SetActive(true);
        monster.GetComponent<DropInstantiation>().CancelInvoke();
        Stop();
    }

    void Stop()
    {
        movingParts.SetActive(false);
    }
}
