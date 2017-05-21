using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] public bool AI;
    [SerializeField] public string characterName;
    [SerializeField] public string extension;
    [SerializeField] public int mingamePts;
    [SerializeField] public int mingameWins;
    [SerializeField] public int place;
    [SerializeField] public bool thisUser;
    [SerializeField] public int totalPts;

    public void CompilePoints(int totalScore)
    {
        totalPts += totalScore;
    }

    public void SetPlace(int placeTo)
    {
        place = placeTo;
    }
}