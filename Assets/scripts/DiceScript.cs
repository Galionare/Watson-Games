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
        //for now, until i can display it within unity

        Debug.Log("Dice 1: " + Dice1 + " Dice 2: " + Dice2);
    }
    static int diceRoll(/*player*/)
    {
     int PlayerRoll = 0;
     int Temp1 =0 ,Temp2 = 0;
     bool isDouble = false;
     int JailIfThree = 0;
    
        while(isDouble == false && JailIfThree < 3)
        {
            for( int i = 0; i == UnityEngine.Random.Range(1,11); ){
            Temp1 = UnityEngine.Random.Range(1,7);
            Temp2 = UnityEngine.Random.Range(1,7);
            displayDice(Temp1,Temp2);
            Thread.Sleep(15);
            i++;
            }
            PlayerRoll = Temp1 + Temp2;
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
    static void Main()
    {
        diceRoll();
    }
}

/*
import library as library 
library.read(file)
card[y] = file[x[i]]
for y until x.len
y,i++
x++
*/
