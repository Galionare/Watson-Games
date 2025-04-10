using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex; // Unique index for each player
    public string playerName; // Optional: to store player's name
    public bool passedGO = false;
    public int money;
    public int position;
    public int jailTurn;
    public List<string> cards;
}
