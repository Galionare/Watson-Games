using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class OnHoverHelpFullGame : MonoBehaviour
{
   public GameObject helpText; 
   

    // Update is called once per frame
    void OnMouseOver()
    {
        UnityEngine.Debug.Log("Mouse is over the object");
        helpText.SetActive(true);
    }
    void OnMouseExit()
    {
        UnityEngine.Debug.Log("Mouse is no longer over the object");
        helpText.SetActive(false);
    }
}


// property blueGroup[] = blueGroup.append(groupi[] = groupi[0] = property.NameProperty)


// array = Array.Find(groups, g => g.StartsWith(property.Group));
//array.append(property.NameProperty) (assuming passed by reference)


// Switch(property.Group)
// {
//     case "blue":
//        blueGroup.append(property.NameProperty);}

//Switch(property.Group)
//     case "red":
//        redGroup.append(property.NameProperty);
//     case "green":                
//        greenGroup.append(property.NameProperty);
//     case "yellow":