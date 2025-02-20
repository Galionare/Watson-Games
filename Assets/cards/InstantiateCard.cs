using UnityEngine;

public class InstantiateCard : MonoBehaviour
{

    [SerializeField] GameObject Property;
    [SerializeField] GameObject mainCanvasObj;


    GameObject flyingSymbol = Instantiate(Property, (0, 0, 0), Quaternion.identity);
    flyingSymbol.transform.SetParent(mainCanvasObj.transform, false);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
