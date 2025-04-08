using UnityEngine;

public class OnHoverAbridgedHelp : MonoBehaviour
{
   public GameObject helpText; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        helpText.SetActive(true);
    }
    void OnMouseExit()
    {
        helpText.SetActive(false);
    }
}
