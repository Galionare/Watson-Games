using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex; // Unique index for each player
    public string playerName; // Optional: to store player's name
    public int money = 1500;
    public int position;
    public int jailTurn;
    public List<string> cards;
    public List<Transform> boardPositions;

    public void MoveToPOsition(int newPosition) 
    {
        position = newPosition;
        if(newPosition >= 0 && newPosition < boardPositions.Count)
        {
            transform.position = boardPositions[newPosition].position;
        }
    }
    public void GoToJail()
    {
        MoveToPOsition(10);
        jailTurn = 3;
    }
}
