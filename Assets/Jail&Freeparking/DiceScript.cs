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

        // Wait for the dice to stop rolling
        Invoke("GameObject.Destroy(newDice)", 10);// Sleep for 1 millisecond to avoid busy waiting
        Invoke("return diceNumber", 10);
        return 0;
    }
<<<<<<< Updated upstream
    public int diceRoll(Player player) //This will take a player variable as a parameter possibly, empty for now as itll probably just be called to return values within a player script during a turn, the method of invoking the dicerolling will be determined in there too, "space to roll" etc, itll then continue to roll automatically with sleeps between if there are doubles
=======

    public int diceRoll() //This will take a player variable as a parameter possibly, empty for now as itll probably just be called to return values within a player script during a turn, the method of invoking the dicerolling will be determined in there too, "space to roll" etc, itll then continue to roll automatically with sleeps between if there are doubles
>>>>>>> Stashed changes
    {
     int PlayerRoll = 0; //Initialises their roll as 0 from last turn
     int Temp1 =0 ,Temp2 = 0;
     bool isDouble = false;
     int JailIfThree = 0;
    
    
     Temp1 = Roll(); //Calls the function within the RollDice Script to roll the board dice visually/physically for the player
     Temp2 = Roll();
     PlayerRoll += Temp1 + Temp2; //Adds the two dice rolls together to get the total roll for the player
<<<<<<< Updated upstream
            if(Temp1 == Temp2)
            {
                isDouble = true;
                JailIfThree++;
                while(isDouble == true && JailIfThree != 3) //Rolls Again if user rolled a double, will do this until 3 doubles have been reached OR a double is not rolled
                {
                    Debug.Log("You rolled a double! Roll again!");
                    Temp1 = Dice.Roll();
                    Temp2 = Dice.Roll();
                    PlayerRoll += Temp1 + Temp2;
                    if(Temp1 == Temp2)
                    {
                        JailIfThree++;
                        Debug.Log("You rolled a double! Roll again!");
                    }
                    else
                    {
                        isDouble = false;
                        PlayerRoll += Temp1 + Temp2;
                        break;
                    }
                }
            }
        
        if(JailIfThree == 3 /*optional: AND IF player does NOT have get out of jail free, and deincrement if they do(impossible as of right now as the other devs have not done player nor potluck*/) //Jail Check
        {
<<<<<<< HEAD
           Jail.GoToJail(player); //Calls Function to put the player in jail see JailScript.cs
=======
           //Jail.GoToJail(player); //Calls Function to put the player in jail see JailScript.cs
>>>>>>> 1e9adce638834c3128459b15500c0ed8339188e3
           Debug.Log("Go to Jail");
            return 0;  //Ignore: Int method so this needs to return something, this ensures they dont move and will stay in jail. 
        }
        else
        { 
            Debug.Log("Player Roll " + PlayerRoll);
=======
            
>>>>>>> Stashed changes
            return PlayerRoll; //Returns Combined value of the dicerolls (including possible extras from doubles)
        }
    }


