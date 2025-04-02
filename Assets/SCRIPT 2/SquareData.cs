using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SquareData : MonoBehaviour
{
    private int position;
    private Dictionary<int, PropertyData> propertyData;
    [SerializeField] private TextMeshPro Name;
    [SerializeField] private TextMeshPro Cost;
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
        Name.text = $"{data.NameProperty}";
        if (data.CanBeBought)
        {
            Cost.text = $"£{data.Cost}";
            Cost.gameObject.SetActive(true);
            Action.gameObject.SetActive(false);
        }
        else
        {
            Action.text = $"{data.Action}";
            Cost.gameObject.SetActive(false);
            Action.gameObject.SetActive(true);
        }
    }

}