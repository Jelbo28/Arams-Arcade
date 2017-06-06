using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimationTransitions : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Animator exitAnimator;

    [SerializeField]
    Animator monsterAnimator;

    [SerializeField]
    GameObject thump;

    [SerializeField]
    GameObject fade;

    [SerializeField]
    AudioSource boop;

    [SerializeField]
    AudioSource badFeeling;

    [SerializeField]
    AudioSource fatLady;

    [SerializeField]
    AudioSource fatLadysing;

    [SerializeField]
    AudioSource creation;

    [SerializeField]
    AudioSource monster;

    [SerializeField]
    AudioSource quit;

    [SerializeField]
    AudioSource start;
    #endregion

    public void Menu()
    {
        boop.Play();
        StartCoroutine(WaitForAudio(boop));
        //Debug.Log("Back to menu.");
        // Use this to load whatever scene the title screen is on.
        SceneManager.LoadScene("Title Menu");
    }

    public void Credits()
    {
        boop.Play();
        StartCoroutine(WaitForAudio(boop));
        //Debug.Log(boop.clip.length);
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        //Debug.Log("Quits");
        quit.Play();
        StartCoroutine(WaitForAudio(quit));
        Application.Quit();
    }

    public void StartButton()
    {
        start.Play();
        StartCoroutine(WaitForAudio(start));
        //Debug.Log("Play");
        fade.SetActive(true);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Cutscene()
    {
        SceneManager.LoadScene("IntroCutscene");
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void ButtonGlow()
    {
        exitAnimator.SetBool("ButtonGlow", true); 
    }

	public void ThumpEffect()
	{
		thump.GetComponentInChildren<ParticleSystem>().Play(true);
	}

    public void BadFeeling()
    {
        badFeeling.Play();
    }

    public void Creation()
    {
        creation.Play();
    }

    public void Monster()
    {
        monster.Play();
    }

    public void FatLady()
    {
        fatLady.Play();
    }


    public void Sing()
    {
        fatLadysing.Play();
    }

    public void FatLadyGo()
    {
        gameObject.GetComponent<Animator>().SetBool("FatLadySing", true);
    }

    public void MonsterTime()
    {
        monsterAnimator.SetBool("MonsterTime", true);
    }

    IEnumerator WaitForAudio(AudioSource name)
    {
        yield return new WaitForSeconds(name.clip.length);
    }
}
