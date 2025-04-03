using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UtilityCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;

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
            if (data.CanBeBought && (data.Group.Contains("Utilities")))
            {
                Name.text = $"{data.NameProperty}";
                Info1.text = $"{data.UtilRent1}";
                Info2.text = $"{data.UtilRent2}";
            }
        }
    }
}