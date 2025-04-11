using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Threading;
using UnityEditor;
public class DiceScript : MonoBehaviour
{

    //Player = 
    public GameObject gameDice;
    int diceCount = 0;
    public int Roll()
    {
        /*
        Instantiate(gameDice);
        return DiceRolling.diceNumber;
        Destroy(gameDice);
        */
        diceCount++;
        GameObject newDice = Instantiate(gameDice);
        newDice.name = "Dice" + diceCount;
        newDice.transform.position = new Vector3(2*diceCount, 8, 0);

        DiceRolling diceRolling = newDice.GetComponent<DiceRolling>();
        int diceNumber = diceRolling.diceNumber;
        while (diceNumber == 0) // Wait for the dice to stop rolling
        {
            diceNumber = diceRolling.diceNumber; // Update the dice number
        }
        // Wait for the dice to stop rolling
        GameObject.Destroy(newDice);// Sleep for 1 millisecond to avoid busy waiting
        return diceNumber;
    }

    public int diceRoll() //This will take a player variable as a parameter possibly, empty for now as itll probably just be called to return values within a player script during a turn, the method of invoking the dicerolling will be determined in there too, "space to roll" etc, itll then continue to roll automatically with sleeps between if there are doubles
    {
     int PlayerRoll = 0; //Initialises their roll as 0 from last turn
     int Temp1 =0 ,Temp2 = 0;
     bool isDouble = false;
     int JailIfThree = 0;
    
    
     Temp1 = Roll(); //Calls the function within the RollDice Script to roll the board dice visually/physically for the player
     Temp2 = Roll();
     PlayerRoll += Temp1 + Temp2; //Adds the two dice rolls together to get the total roll for the player
            
            return PlayerRoll; //Returns Combined value of the dicerolls (including possible extras from doubles)
        }
    }


