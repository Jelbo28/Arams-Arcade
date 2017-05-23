using UnityEngine;
using UnityEngine.UI;

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

    private void Awake()
    {
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


                if (Input.GetMouseButtonDown(0) && clickBuffer <= 0)
                {
                    //Debug.Log("Ayyy");
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
}