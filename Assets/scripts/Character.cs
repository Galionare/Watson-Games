using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Character : MonoBehaviour
{
    public Walking currentRoute;
    int routePosition;

    public int steps;

    bool isMoving;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 7);
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
