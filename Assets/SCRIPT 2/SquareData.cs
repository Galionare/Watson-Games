using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SquareData : MonoBehaviour
{
    private int position;
    private Dictionary<int, PropertyData> propertyData;
    [SerializeField] private TextMeshPro Name;
    [SerializeField] private TextMeshPro Price;
    [SerializeField] private TextMeshPro Action;

    void Start()
    {
        propertyData = CSVLoader.LoadPropertyData();


        if (int.TryParse(gameObject.name, out position) && propertyData.TryGetValue(position, out PropertyData data))
        {
            DisplayTileData(data);
        }
    }
    private void DisplayTileData(PropertyData data)
    {
        Name.text = $"Name: {data.NameProperty}";
        if (data.CanBeBought)
        {
            Price.text = $"Price: £{data.Price}";
            Price.gameObject.SetActive(true);
            Action.gameObject.SetActive(false);
        }
        else
        {
            Action.text = $"Action: {data.Action}";
            Price.gameObject.SetActive(false);
            Action.gameObject.SetActive(true);
        }
    }

}