using UnityEngine;

public class ButtonSc : MonoBehaviour
{
    void Start()
    {
   //     ShowButton();
    }

    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }
}
