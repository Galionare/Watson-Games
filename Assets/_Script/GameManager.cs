using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerFab;
    public int maxPlayer = 5;
    public List<GameObject> playerCount = new List<GameObject>();
    private int currentPlayerI = 0;
    public GameState currentState;

    void Start()
    {
    }

    public void StartingGame()
    {
        SwitchState(GameState.Start);
    }

    void SwitchState(GameState newState)
    {
        currentState = newState;

        // Handle specific actions based on the new state
        switch (newState)
        {
            case GameState.Start:
                SpawnPlayers(); 
                SwitchState(GameState.PlayerTurn);
                Debug.Log("Start State");// Move to the PlayerTurn state after spawning players
                break;

            case GameState.PlayerTurn:
                StartTurn();
                Debug.Log("Player turn ");// Start the first player's turn
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
            int playerIndex = playerCount.Count;  // The index will be the position in the list
            Player playerScript = addPlayer.GetComponent<Player>();  // Get the Player script attached to the player
            playerScript.playerIndex = playerIndex;
            Debug.Log("Player " + playerIndex + " spawned with index: " + playerScript.playerIndex);
        }
    }
    public void StartTurn()
    {
        // Get the current player
        GameObject currentPlayer = playerCount[currentPlayerI];
        Player playerScript = currentPlayer.GetComponent<Player>();  // Get the Player script attached to the current player
        Debug.Log("It's Player " + playerScript.playerIndex + "'s turn!");

        // Logic for the current player's turn goes here (e.g., moving, buying properties, etc.)

        // After the turn ends, switch to the next player
        EndTurn();
    }

    // Method to end the current player's turn and switch to the next player
    public void EndTurn()
    {
        // Move to the next player
        currentPlayerI = (currentPlayerI + 1) % maxPlayer;  // This will loop back to the first player after the last player

        // Call StartTurn() to begin the next player's turn
        StartTurn();
    }
}
public enum GameState
{
    Start,
    PlayerTurn,
    GameOver
}


