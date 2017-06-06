using UnityEngine;

public class BrokenMachine : MonoBehaviour
{
    private MachineController[] machines;
    private MinigameController minigameController;

    private void Start()
    {
        machines = GetComponentsInChildren<MachineController>();
        minigameController = FindObjectOfType<MinigameController>();
    }

    public void EndGame()
    {
        for (var i = 0; i < machines.Length; i++)
        {
            if (machines[i].transform.GetChild(0).name == "Player")
            {
                machines[i].transform.GetChild(0).GetComponent<BMObjectInteraction>().gameOver = true;
            }
            else
            {
                machines[i].gameOver = true;
            }
        }
        minigameController.displayManager.endGame = true;
    }
}