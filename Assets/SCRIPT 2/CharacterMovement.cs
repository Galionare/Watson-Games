using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class CharacterMovement : MonoBehaviour
{
    JailScript JailScript;
    private Walking currentRoute;
    int routePosition;
    public int steps;
    bool isMoving;
    public DiceScript DiceScript;
    public Player Player;

    private void Start()
    {
            currentRoute = FindFirstObjectByType<Walking>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = DiceScript.diceRoll(Player);
            Debug.Log("Rolled" + steps);
            StartCoroutine(Move());

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
            routePosition%= currentRoute.objChildList.Count;
            Vector3 nextPos = currentRoute.objChildList[routePosition].position;
            while (moveNext(nextPos)) { yield return null;}

            yield  return new WaitForSeconds(0.1f);
            steps--;
            
        }
        isMoving = false;
    }
    bool moveNext(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position,target,8f * Time.deltaTime));
    }
}
