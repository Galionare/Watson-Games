using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbridgedGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timeLeft = 2700f; // Time in seconds  
    public TMP_Text timerText; // Reference to the UI Text component for displaying the timer
    void GameOver(){
        //CANT IMPLEMENT ANY OF THIS AS THERE IS NO MULTIPLAYER FUNCTION YET IMPLEMENTED BY THE PLAYER DEVELOPER

        //for playerIndex until players.Count 
        //PreviousPlayerMoney = 0
        //check if this.player (at the index) .money
        //playerMoney = player.money
        //if playerMoney > PreviousPlayerMoney 
        //playerWinner = player.playerIndex
        //PreviousPlayerMoney = playerMoney
        //break the loop
        //Display Winner via text
        //Thread.Sleep(10000); // Wait for 10 seconds before closing the game
        //Application.Quit(); // Close the game
        


        //all players money in a list .max
        //the player ID it returns is the winner
        //Debug.Log("Player " + playerID + " wins with $" + playerMoney[playerID] + "!");
        // Display the winner as text on screen basically a variable + string to edit the text and then enable the object
        Debug.Log("Game Over!");
        // Add any additional game over logic here, such as resetting the game or displaying a message
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timeLeft -= Time.deltaTime; // Get the TextMeshPro component attached to this GameObject
         float minutes = Mathf.Floor(timeLeft / 60);
        double seconds = Math.Round(timeLeft%60, 0);

         timerText.SetText(minutes + ":" + seconds); // Update the text with the remaining time
    if ( timeLeft <= 0 )
    {
        GameOver();
    }
    }
}
