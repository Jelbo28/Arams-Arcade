using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public PlayerInfo[] players;

    private void Start()
    {
        players = GetComponentsInChildren<PlayerInfo>();
    }
}