using UnityEngine;
using System.Collections.Generic;

public class SquareData : MonoBehaviour
{
    private int position;
    private Dictionary<int, PropertyData> propertyData;

    void Start()
    {
        if (int.TryParse(gameObject.name, out position))
        {
            propertyData = CSVLoader.LoadPropertyData();
        }
    }
}