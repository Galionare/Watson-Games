using UnityEngine;

public class JailScript : MonoBehaviour
{
    //This script has a million errors because the script this script RELIES on in the timeline is not done (looking at you emil) but its been so long i just gotta get this done 

    public GameObject GetOutJail;

    // OBSTACLE: Should JustVisiting be a seperate tile ontop of tile 11(jail) eg 11.5 or should it just be a playerstate when the player is in jail? honestly having Jail be its own tile not within the standard array of movement for the player is infinitely easier to implement.
    // Solution, without the calling of the jail script a player should be able to sit on the jail square just fine without anything negative, this can act as JustVisiting
    FreeParkiingScript ParkingScript;
    private Player player;
    void Release(Player player)
    {
        player.GetComponent<Player>().position = 10;
    }
    int checkTurnsToWait(Player player)
    {
        
            return player.jailTurn;
            //somewhat redundant since turnsToWait will be initialised within the player script and can be checked there, but this is here for clarity
        
    }
    public void GoToJail(Player player)
    {
        int beforeJailPos = player.GetComponent<Player>().position; //wont be needed but is useful to have for debugging purposes. 
        player.GetComponent<Player>().position = 11;
        bool playerPaid = false;
        player.GetComponent<Player>().jailTurn = 0;
        bool playerWantToPay = false;
        //ask them if theyd like to pay 50 to get out, also as a side effect lets them save the get out of jail free if they want to
        if (player.GetComponent<Player>().Owned.Contains(GetOutJail))
        {
            player.GetComponent<Player>().Owned.Contains(GetOutJail);
            //make sure this is placed at the bottom of the card pile, the card developer will have to make sure this is the case
            playerPaid = true;
            Release(player);
        }
        else if (player.GetComponent<Player>().money >= 50 && playerWantToPay)
        {
            player.GetComponent<Player>().money -= 50;
            ParkingScript.freeParkingFines += 50;
            //money is added to the free parking pool
            playerPaid = true;
            Release(player);
        }
        else
        {
            //wait for 3 turns
            player.GetComponent<Player>().jailTurn = 3;
            //this will be checked via checkTurnsToWait() in the player script and decremented each turn also within said script if it has returned a value above 0
        //once a player is released after 3 turns itll still be on the jail square, this is fine as the player will be able to move from here as normal. 
        }
    }


}