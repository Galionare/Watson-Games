using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class CharacterMovement : MonoBehaviour
{
    private Walking currentRoute;
    int routePosition;
    public int steps;
    bool isMoving;
    public DiceScript dice;
    public GameObject Player;
    private Player playerScript;
    private JailScript jailScript;
    FreeParkiingScript ParkingScript;
    CharacterMovement characterMovement;

    private void Start()
    {
        currentRoute = FindFirstObjectByType<Walking>();
        playerScript = GetComponent<Player>();
        jailScript = GetComponent<JailScript>();
        ParkingScript = FindFirstObjectByType<FreeParkiingScript>();

    }

    public void jailGO(Player player)
    {
        StartCoroutine(GoToJailMove());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = dice.diceRoll(playerScript,jailScript,characterMovement, dice) ; //Random.Range(1, 13);
            Debug.Log("Rolled: " + steps);
            StartCoroutine(Move());
        }

        if (!isMoving && playerScript.position == 30)
        {
            StartCoroutine(GoToJailMove());
        }
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.objChildList.Count;
            Vector3 nextPos = currentRoute.objChildList[routePosition].position;
            while (!moveNext(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
        }

        isMoving = false;
        playerScript.position = routePosition;
    }

    bool moveNext(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 12f * Time.deltaTime);
        return transform.position == target;
    }
    
    IEnumerator GoToJailMove()
    { 
        routePosition = 10;
        Vector3 nextPos = currentRoute.objChildList[routePosition].position;
        while (!moveNext(nextPos)) { yield return null; }
        yield return new WaitForSeconds(0.1f);
        jailScript.GoToJail(playerScript);
    }

    
}