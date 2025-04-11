using UnityEngine;

public class DiceScript : MonoBehaviour
{
    CharacterMovement movementScript;
    public int diceRoll(Player player, JailScript jailScript, CharacterMovement movementScript, RollDice roller)
    {
        int playerRoll = 0;
        int temp1 = 0, temp2 = 0;
        int jailIfThree = 0;
        bool isDouble = false;

        temp1 = roller.Roll(player);
        temp2 = roller.Roll(player);
        playerRoll += temp1 + temp2;

        Debug.Log("Dice 1: " + temp1 + " Dice 2: " + temp2);

        if (temp1 == temp2)
        {
            isDouble = true;
            jailIfThree++;

            while (isDouble && jailIfThree < 3)
            {
                Debug.Log("You rolled a double! Roll again!");

                temp1 = roller.Roll(player);
                temp2 = roller.Roll(player);
                Debug.Log("Dice 1: " + temp1 + " Dice 2: " + temp2);

                playerRoll += temp1 + temp2;

                if (temp1 == temp2)
                {
                    jailIfThree++;
                }
                else
                {
                    isDouble = false;
                }
            }
        }

        if (jailIfThree == 3)
        {
            Debug.Log("Three doubles! Go to Jail.");
            StartCoroutine(movementScript.GoToJailMove());
            return 0;
        }

        Debug.Log("Total Player Roll: " + playerRoll);
        return playerRoll;
    }
}
