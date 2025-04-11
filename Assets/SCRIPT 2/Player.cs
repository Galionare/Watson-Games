using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex; // Unique index for each player
    public string playerName; // Optional: to store player's name
    public int money = 1500;
    public int position;
    public int jailTurn;
    public List<PropertyData> owned;
    public bool isRolled = false;
    public bool passedGo = false;
    public int index;

    /* if (position == 21){
            FreeParkiingScript.LandedOnFreeParking(this.Player); 

        }
        */
}
