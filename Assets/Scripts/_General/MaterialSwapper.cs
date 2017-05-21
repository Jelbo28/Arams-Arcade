using System.Collections;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    [SerializeField] private float swapSpeed;
    [SerializeField] private bool random = true;
    public bool reset;
    public bool stop = false;
    [SerializeField] private Material[] facesTextures;
    private Renderer thisRenderer;

    private void Start()
    {
        thisRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!reset)
        {
            StopAllCoroutines();
            StartCoroutine(Rolling());
            reset = true;
        }
    }

    private IEnumerator Rolling()
    {
        var i = 0;
        var oldI = 0;
        while (!stop)
        {
            if (random)
            {
                while (i == oldI)
                {
                    i = Mathf.RoundToInt(Random.Range(0, facesTextures.Length - 1.1f));
                }
                thisRenderer.material = facesTextures[i];
                oldI = i;
            }
            else
            {
                i = oldI < facesTextures.Length ? oldI : 0;
                thisRenderer.material = facesTextures[i];
                oldI = i + 1;
            }
            yield return new WaitForSeconds(swapSpeed);
        }
    }
}
