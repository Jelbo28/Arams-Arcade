//using UnityEngine;

//public class UselessGM : MonoBehaviour
//{
//    private PlayerBanner bannerControl;
//    // Use this for initialization
//    private CameraFollow cameraSetup;
//    private DisplayManager dispManager;
//    [SerializeField] private bool newGame;
//    private int[] playerRollNum;
//    [SerializeField] private Player[] players;
//    private int playerTurn;

//    private void Start()
//    {
//        bannerControl = FindObjectOfType<PlayerBanner>();

//        cameraSetup = FindObjectOfType<CameraFollow>();
//        players = GameObject.Find("Ships").GetComponentsInChildren<Player>();
//        dispManager = FindObjectOfType<DisplayManager>();
//        if (newGame)
//        {
//            BeginGame();
//        }
//    }

//    public void NewTurn(int currPlayer)
//    {
//        Debug.Log(players[currPlayer].GetComponent<Player>().thisPlayer.characterName);
//        bannerControl.SetPlayer(players[currPlayer].GetComponent<Player>().thisPlayer.characterName);
//        cameraSetup.SetTarget(players[currPlayer].transform.GetChild(2));
//        // Debug.Log(players[currPlayer].transform.GetChild(2).name);
//    }

//    private void BeginGame()
//    {
//        //dispManager.BeginGame();
//        NewTurn(Random.Range(0, players.Length));
//    }
//}