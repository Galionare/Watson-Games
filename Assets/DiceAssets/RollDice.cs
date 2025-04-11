//Some method name RollDice() that instantiates a new gameobject of dice, with name DiceX where X is the number of dice i++ each time a new dice is created and transform.position is set to x coord++ if one already exists
//this PUBLIC(?) method will then be directly called via DiceScript.cs to return the number on the top face of the dice which will be grabbed from some Method in DiceRolling.cs

using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Threading;
using UnityEditor;
using JetBrains.Annotations;


public class RollDice : MonoBehaviour
{
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
        Rigidbody rb = GetComponent<Rigidbody>();
        newDice.name = "Dice" + diceCount;
        newDice.transform.position = new Vector3(2*diceCount, 8, 0);

        DiceRolling diceRolling = newDice.GetComponent<DiceRolling>();
        int diceNumber = diceRolling.diceNumber;
        
            // Wait for the dice to stop rolling
            Thread.Sleep(1000); // Sleep for 1 millisecond to avoid busy waiting
        
        Destroy(newDice);
        return diceNumber;
    }

}