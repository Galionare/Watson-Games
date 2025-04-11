using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int playerIndex; // Unique index for each player
    public string playerName; // Optional: to store player's name
    public int money = 1500;
    public int position;
    public int jailTurn;
    public List<string> cards;
    public List<Transform> boardPositions;
    private ShowPropery showPropery;

    public void MoveToPosition(int newPosition)
    {
        position = newPosition;
        Debug.Log("Working");
        if (newPosition >= 0 && newPosition < boardPositions.Count)
        {
            // Move the player's actual position in the game world
            transform.position = boardPositions[newPosition].position;
        }
        showPropery.ShowProp(position);


    }

    public void GoToJail()
    {
        MoveToPosition(10);  // Move to jail position (position 10)
        jailTurn = 3;        // Set the number of turns the player will be in jail
    }

}
