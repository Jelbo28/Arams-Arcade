using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float[] acceptableRotations = new float[4];
    [SerializeField] private bool interactable = true;
    [SerializeField] private int pipeType = 0;
    [SerializeField] private bool scrambleIt = true;
    public bool correctRot;
    [SerializeField] private float currRotation;
    public bool finalPipe = false;
    private PipesManager manager;
    public Pipe[] neighbors;
    private int scramble;

    private void Start()
    {
        manager = FindObjectOfType<PipesManager>();
        for (int i = 0; i < acceptableRotations.Length; i++)
        {
            currRotation = transform.rotation.eulerAngles.z;

            acceptableRotations[i] = transform.rotation.eulerAngles.z;
            switch (pipeType)
            {
                case 0:
                    Rotate();
                    Rotate();
                    Rotate();
                    Rotate();
                    break;
                case 1:
                    Rotate();
                    Rotate();
                    break;
                case 2:
                    Rotate();
                    break;
            }
        }
        if (interactable && scrambleIt)
        {
            scramble = Random.Range(1, 4);
            for (int i = 0; i < scramble; i++)
            {
                Rotate();
            }
        }
    }

    private void Update()
    {
        CheckRotation();
    }

    public void Rotate()
    {
        if (interactable)
        {
            transform.Rotate(0, 0, 90, Space.Self);
            currRotation = transform.rotation.eulerAngles.z;

            CheckRotation();
        }
    }

    private void CheckRotation()
    {
        foreach (float rotation in acceptableRotations)
        {
            if (currRotation == rotation)
            {
                correctRot = true;
                break;
            }
            correctRot = false;
        }
    }

    public void ActivateNeighbors()
    {
        if (!finalPipe)
        {
            foreach (var neighbor in neighbors)
            {
                neighbor.GetComponent<Animator>().SetBool("Break", !neighbor.correctRot);
                manager.minigameController.AddPoints(1);
                neighbor.GetComponent<Animator>().SetTrigger("PipeGo");
            }
        }
        else
        {
            manager.SetLevel();
        }
    }

    public void GameOver()
    {
        manager.minigameController.thisPlayer.mingamePts -= 5;
        manager.minigameController.thisPlayer.SetPlace(3);
        manager.minigameController.displayManager.endGame = true;
        //Debug.Log("Game Over!! You freaking suck at this!");
    }
}