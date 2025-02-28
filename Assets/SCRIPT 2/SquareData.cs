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
        foreach (var entry in propertyData)
        {
            PropertyData data = entry.Value;

            if (data.CanBeBought)
            {
                Debug.Log($"ID: {data.Position}, Name: {data.NameProperty}, Group: {data.Group}, Price: {data.Price}, Rent: {data.Rent}, Rent with houses: {string.Join(", ", data.Houses)}");
            }
            else
            {
                Debug.Log($"ID: {data.Position}, Name: {data.NameProperty}, Action: {data.Action} (Not Buyable)");
            }
        }
    }
}