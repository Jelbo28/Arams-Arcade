using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private Image crosshair;
    [SerializeField] private Color crosshairHighlight;
    [SerializeField] private Color crosshairNormal;
    [SerializeField] private GameObject indexCard;
    private bool indexUp;
    [SerializeField] private float viewDistance;
    [SerializeField]
    private float clickBuffer;
    private float origClickBuffer;
    [SerializeField]
    private float bloomLimit = 10f;
    [SerializeField] private Bloom noBloomCam;
    [SerializeField] private bool bloomOut = false;
    [SerializeField] private Animator whiteFade;
    private string targetScene;
    private SceneChanger sceneChanger;

    private void Awake()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
        origClickBuffer = clickBuffer;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, viewDistance))
        {
            Debug.DrawLine(ray.origin, hit.point);

            if (hit.transform.tag == "Interactable")
            {
                indexCard.GetComponent<Animator>().SetTrigger("SlideUp");
                indexUp = true;
                indexCard.GetComponentInChildren<Text>().text = hit.transform.GetComponent<Text>().text;
                crosshair.color = crosshairHighlight;


                if (Input.GetMouseButtonDown(0) && clickBuffer <= 0 && hit.transform.name == "Arcade Machine")
                {
                    targetScene = hit.transform.parent.parent.name;
                    sceneChanger.sceneAfter = hit.transform.parent.parent.name;
                    bloomOut = true;
                    Debug.Log(targetScene);
                    clickBuffer = origClickBuffer;

                }

                else if(clickBuffer > 0)
                {
                    clickBuffer -= Time.deltaTime;
                }
            }
            else
            {
                CardDown();
            }
        }
        else
        {
            CardDown();
        }
        if (bloomOut)
            BloomOut();
    }

    void CardDown()
    {
        if (indexUp)
        {
            indexCard.GetComponent<Animator>().SetTrigger("SlideDown");
            indexUp = false;
        }
        crosshair.color = crosshairNormal;
    }

    void BloomOut()
    {
        Debug.Log(noBloomCam.settings.intensity);
        if (noBloomCam.settings.intensity < bloomLimit)
        {
            noBloomCam.settings.intensity += Time.deltaTime * 25;
        }
        else
        {
            Debug.Log("Bloom done!");
            //SceneManager.LoadScene(targetScene);
            sceneChanger.LoadSceneByName();
        }
        if (noBloomCam.settings.intensity > 42 && !whiteFade.enabled)
        {
            whiteFade.enabled = true;
        }

    }
}