using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using System.Linq;
using System;

public class DiceRolling : MonoBehaviour
{ 
    public Vector3 direction = new Vector3(1, 1, 0); //throws upwards and to the side
    private Rigidbody rb;
    public int diceNumber;
    private SphereCollider[] colliders;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        colliders = GetComponentsInChildren<SphereCollider>();
        diceNumber = 0;
        transform.rotation = UnityEngine.Random.rotation; //starts the throw in a random direction effectively, could probably randmoise the vectors but this is cleaner
        //transform.position = direction * Time.deltaTime; (was always throwing from world origin? probably timedelta starting at 0?)
        rb.AddForce(direction * 9, ForceMode.Impulse); //the throw itself, adding velocity effectively using direction * force 
        
    }
    void Update()
    {
        Debug.Log("1. Update Method is actually running");
        if (rb.linearVelocity == Vector3.zero)
        {
            SphereCollider topCollider = colliders.OrderByDescending(c => c.transform.position.y).FirstOrDefault();
            diceNumber = Int32.Parse(topCollider.name);
            /*
            float maxY = colliders.Max(c => c.transform.position.y);
            //int maxY = Mathf.RoundToDouble(floatMaxY); this fix doesnt work as the float is so small that it rounds to 1 always
           switch (maxY) {
                case 1:
                     diceNumber = 1;
                     break;
                case 2:
                     diceNumber = 2;
                     break;
                case 3:
                     diceNumber = 3;
                     break;
                case 4:
                     diceNumber = 4;
                     break;
                case 5:
                     diceNumber = 5;
                     break;
                case 6:
                     diceNumber = 6;
                     break;
                     
              }
             */
        }
         Debug.Log("Dice Number: " + diceNumber);
    }
    
    //Some Method That Returns the top facing number, be it using raycast or having a collision on the opposite side labelled with its number
    //only AFTER velocity is 0 and NOT when velocity is 0 in the starting frame, sleep for 1ms is a conditional fix that will serve fine
}