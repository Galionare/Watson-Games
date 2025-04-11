using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public GameObject playerFab;
    public int maxPlayer = 5;
    private List<GameObject> playerCount = new List<GameObject>();
    public int currentPlayerI = 0;
    public GameState currentState;
    public GameObject hands;
    public GameObject hands2;
    public TMP_InputField nameInput;
    void Start()
    {

    }
    public void GameStart()
    {
        SwitchState(GameState.Start);
    }

    void SwitchState(GameState newState)
    {
        currentState = newState;


        switch (newState)
        {
            case GameState.Start:
                SwitchState(GameState.PlayerTurn);
                Debug.Log("Start State");
                break;

            case GameState.PlayerTurn:
                StartTurn();
                Debug.Log("Player turn ");
                break;

            case GameState.GameOver:
                Debug.Log("Game Over!");
                break;
        }
    }

    public void SpawnPlayers()
    {
        if (playerCount.Count < maxPlayer)
        {
            GameObject addPlayer = Instantiate(playerFab);
            playerCount.Add(addPlayer);

            int playerIndex = playerCount.Count - 1;
            Player playerScript = addPlayer.GetComponent<Player>();
            playerScript.playerIndex = playerIndex;
            Debug.Log("Player " + playerIndex + " spawned with index: " + playerScript.playerIndex);
            hands.SetActive(true); // Set the hands GameObject active
            if(playerCount.Count == 2){
              hands2.SetActive(true); // Set the hands2 GameObject inactive
            }
            
        }
    }
    public void StartTurn()
    {
        GameObject currentPlayer = playerCount[currentPlayerI];
        Player playerScript = currentPlayer.GetComponent<Player>();
        Debug.Log("It's Player " + playerScript.playerIndex + "'s turn!");
        playerScript.isRolled = false;
        Debug.Log("Now it's player index: " + currentPlayerI);
    }


    public void EndTurn()
    {
        GameObject currentPlayer = playerCount[currentPlayerI];
        Player playerScript = currentPlayer.GetComponent<Player>(); 
        Debug.Log(currentPlayerI);
        Debug.Log("Checking isRolled for player " + playerScript.playerIndex + ": " + playerScript.isRolled);
        if (playerScript.isRolled == true)
        {
            currentPlayerI = (currentPlayerI + 1) % playerCount.Count;
            StartTurn();
        }
        else Debug.Log("FUCK YOU");
    }
}
public enum GameState
{
    Start,
    PlayerTurn,
    GameOver
}


