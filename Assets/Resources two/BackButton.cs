using UnityEngine;

public class BackButton : MonoBehaviour
{

    void Start()
    {
        HideButton();
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
