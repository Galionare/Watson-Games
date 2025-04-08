using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Threading;
using UnityEditor;
public class NewEmptyCSharpScript
{
    int Dice1,Dice2,PlayerRoll;
    //Player = 

    static void displayDice(int Dice1, int Dice2)
    {
        //optional method to display the dice rolls onscreen, for now is being used to test the method. 

        Debug.Log("Dice 1: " + Dice1 + " Dice 2: " + Dice2);
    }
    static int diceRoll(/*player*/) //This will take a player variable as a parameter possibly, empty for now as itll probably just be called to return values within a player script during a turn, the method of invoking the dicerolling will be determined in there too, "space to roll" etc, itll then continue to roll automatically with sleeps between if there are doubles
    {
     int PlayerRoll = 0;
     int Temp1 =0 ,Temp2 = 0;
     bool isDouble = false;
     int JailIfThree = 0;
    
        while(isDouble == false && JailIfThree < 3)
        {
            for( int i = 0; i == UnityEngine.Random.Range(1,11); ){
            Temp1 = UnityEngine.Random.Range(1,7); //Replace this with a call to RollDice method, this method should simply create an instance of a dice gameobject and then take the number returned from the method within DiceRolling.cs (attached to the dice)
            Temp2 = UnityEngine.Random.Range(1,7); //Ditto, see above
            displayDice(Temp1,Temp2); //See comment within method
            Thread.Sleep(15); //This sleep was here to simulate "bounces" not knowing when itll stop, can be kept but will most likely be REMOVED once the physics bouncing/dice roll is linked to this script via method mentioned above (see above comment)
            i++;
            }
            PlayerRoll = Temp1 + Temp2; //Finalised Player roll, method returns this value at the end
            if(Temp1 == Temp2)
            {
                isDouble = true;
                JailIfThree++;
            }
        }
        if(JailIfThree == 3)
        {
           // goToJail(player);
           Debug.Log("Go to Jail");
            return 0;
        }
        else
        { 
            Debug.Log("Player Rolled: " + PlayerRoll);
            return PlayerRoll;
        }
    }
   
}

