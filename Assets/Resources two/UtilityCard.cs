using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UtilityCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;

    private int position = 13;
    private Dictionary<int, PropertyData> propertyData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData.TryGetValue(position, out PropertyData data))
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