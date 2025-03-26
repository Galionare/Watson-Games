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

    private int Position = 6;
    private Dictionary<int, PropertyData> propertyData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        propertyData = CSVLoader.LoadPropertyData();
        Debug.Log(Position+"Station"); 
        
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
