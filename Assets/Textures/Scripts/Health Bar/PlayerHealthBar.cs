using UnityEngine;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    void Awake()
    {
        health.Initialize();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            health.CurrentValue -= 25;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            health.CurrentValue += 25;
        }
    }

    public void Damage()
    {
        //Debug.Log(gameObject.tag);
        if (gameObject.name == "Ninja Player")
        {
            health.CurrentValue -= 25f;
            if (health.CurrentValue <= 0)
            {
                //Debug.Log("Dead");
				//gameObject.GetComponent<AnimationTransitions>().Gameover();
                //GM.instance.GameLost();
            }
        }
        /*
        else if (gameObject.name == "Player 2")
        {
            health.CurrentValue -= 7f;
            if (health.CurrentValue <= 0)
            {
                //GM.instance.GameWon();
            }
        }
        */    
    }
}
