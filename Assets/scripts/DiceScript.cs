using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Threading;
using UnityEditor;
using System.Collections;
public class DiceScript : MonoBehaviour
{

    //Player = 
    public GameObject gameDice;
    public CharacterMovement player;
    int diceCount = 0;
    Player ps;
    JailScript jailScript;
    public Walking currentRoute;
     public IEnumerator GoToJailMove()
   { 
    player.routePosition = 11;
    Vector3 nextPos = currentRoute.objChildList[player.routePosition].position;
    while (!player.moveNext(nextPos)) { yield return null; }
    yield return new WaitForSeconds(0.1f);
    jailScript.GoToJail(ps);
    }

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
        newDice.transform.position = new Vector3(1*diceCount, 4, 0); //make sure they dont spawn inside eachother

        DiceRolling diceRolling = newDice.GetComponent<DiceRolling>();
        int diceNumber = diceRolling.diceNumber;
        
        
        /// 
   
      
       //Debug.Log("Dice Number: " + diceNumber);
        // Wait for the dice to stop rolling
        //GameObject.Destroy(newDice);// Sleep for 1 millisecond to avoid busy waiting

        diceNumber = UnityEngine.Random.Range(1, 7); // Simulate a dice roll (1-6)
        if (diceCount == 2)
        {
            diceCount = 0;
        }
        
        return diceNumber;
    }

    public int diceRoll() //This will take a player variable as a parameter possibly, empty for now as itll probably just be called to return values within a player script during a turn, the method of invoking the dicerolling will be determined in there too, "space to roll" etc, itll then continue to roll automatically with sleeps between if there are doubles
    {
     int PlayerRoll = 0; //Initialises their roll as 0 from last turn
     int Temp1 =0 ,Temp2 = 0;
     bool isDouble = false;
     int JailIfThree = 0;
    
     Debug.Log("TURN STARTU");
     Temp1 = Roll(); //Calls the function within the RollDice Script to roll the board dice visually/physically for the player
     Temp2 = Roll();
     PlayerRoll += Temp1 + Temp2; //Adds the two dice rolls together to get the total roll for the player
     if(Temp1 == Temp2){
        isDouble = false; 
        Debug.Log("FIRST DOUBLE HAS BEEN ROLLED - " + JailIfThree ); //Debug message for now, will be replaced with a function to send the player to jail
        Temp1 = Roll(); //If the player rolls doubles, they get to roll again, this will be a loop until they roll a non double or 3 doubles in a row
        Temp2 = Roll();
        PlayerRoll += Temp1 + Temp2; //Adds the two dice rolls together to get the total roll for the player
        JailIfThree++;
        if(Temp1 == Temp2){
            isDouble = true; //If they roll a double, they get to roll again
        }
        while(isDouble && JailIfThree < 3){
            JailIfThree++;
            Debug.Log("ANOTHER DOUBLE HAS BEEN ROLLED - Doubles left until Jail " + (3-JailIfThree) ); //If the player rolls doubles, they get to roll again, this will be a loop until they roll a non double or 3 doubles in a row
            Temp1 = Roll(); //Calls the function within the RollDice Script to roll the board dice visually/physically for the player
            Temp2 = Roll();
            PlayerRoll += Temp1 + Temp2; //Adds the two dice rolls together to get the total roll for the player
            if(Temp1 != Temp2){
                isDouble = false; //If they roll a non double, they stop rolling again
            }
            
        }
        
        if(JailIfThree == 3){ //If the player rolls 3 doubles in a row, they go to jail
        
            //player.routePosition = 10;
            GoToJailMove();
            PlayerRoll = 0; //Player goes to jail, so their roll is 0
            Debug.Log("Player goes to Jail"); //Debug message for now, will be replaced with a function to send the player to jail
        }
       

     }
            
            return PlayerRoll; //Returns Combined value of the dicerolls (including possible extras from doubles)
    }
    }


