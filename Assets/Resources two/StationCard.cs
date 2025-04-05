using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class StationCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;
    public TextMeshProUGUI Info3;
    public TextMeshProUGUI Info4;

    public int Position;

    private Dictionary<int, PropertyData> propertyData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateCard(Position);
    }
    public void CreateCard(int Position)
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData.TryGetValue(Position, out PropertyData data))
        {
            if (data.CanBeBought && (data.Group.Contains("Station")))
            {
                Name.text = $"{data.NameProperty}";
                Info1.text = $"{data.StatRent1}";
                Info2.text = $"{data.StatRent2}";
                Info3.text = $"{data.StatRent3}";
                Info4.text = $"{data.StatRent4}";
            }
        }
    }
}
