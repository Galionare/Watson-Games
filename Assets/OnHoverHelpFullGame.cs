using UnityEngine;

public class OnHoverHelpFullGame : MonoBehaviour
{
   public GameObject helpText; 
   

    // Update is called once per frame
    void OnMouseOver()
    {
        Debug.Log("Mouse is over the object");
        helpText.SetActive(true);
    }
    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer over the object");
        helpText.SetActive(false);
    }
}
