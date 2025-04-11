using UnityEngine;

public class DiceScript : MonoBehaviour
{
    CharacterMovement movementScript;
    RollDice diceRoller;

    void Start()
    {
        movementScript = FindFirstObjectByType<CharacterMovement>();
        diceRoller = FindFirstObjectByType<RollDice>();
    }

    public int DiceRoll()
    {
        int playerRoll = 0;
        int temp1 = 0, temp2 = 0;
        int jailIfThree = 0;
        bool isDouble = false;

        temp1 = diceRoller.Roll();
        temp2 = diceRoller.Roll();
        playerRoll += temp1 + temp2;

        Debug.Log("Dice 1: " + temp1 + " Dice 2: " + temp2);

        if (temp1 == temp2)
        {
            isDouble = true;
            jailIfThree++;

            while (isDouble && jailIfThree < 3)
            {
                Debug.Log("You rolled a double! Roll again!");

                temp1 = diceRoller.Roll();
                temp2 = diceRoller.Roll();
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
            movementScript.StartCoroutine(movementScript.GoToJailMove());
            return 0;
        }

        Debug.Log("Total Player Roll: " + playerRoll);
        return playerRoll;
    }
}
