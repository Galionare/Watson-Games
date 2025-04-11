using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{

    private Walking currentRoute;
    public int routePosition;
    public int steps;
    bool isMoving;
    public DiceScript dice;
    public GameObject player;
    public bool done = false;

    private void Start()
    {
            currentRoute = FindFirstObjectByType<Walking>();
            dice = FindFirstObjectByType<DiceScript>();
    }
    private async Task Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isMoving && done != true)
        {
            done = true;
            steps = dice.diceRoll();
            Debug.Log("Rolled" + steps);
            StartCoroutine(Move());
        }
        {
            steps = dice.diceRoll();

            
            Debug.Log("Rolled" + steps);
            StartCoroutine(Move());

        }
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(5f);
        done = false;
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
    public bool moveNext(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position,target,8f * Time.deltaTime));
    }
}
