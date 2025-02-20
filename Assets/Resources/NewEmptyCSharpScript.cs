using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class PropertyLoader : MonoBehaviour
{
    public TextAsset propertyCSV; // Drag and drop the CSV file in the Unity Inspector
    private Dictionary<int, Property> properties = new Dictionary<int, Property>();

    void Start()
    {
        LoadProperties();
    }

    void LoadProperties()
    {
        string[] lines = propertyCSV.text.Split('\n');

        for (int i = 1; i < lines.Length; i++) // Skip header row
        {
            string[] values = lines[i].Split(',');
            if (values.Length < 4) continue;

            int id = int.Parse(values[0]);
            string name = values[1];
            int price = int.Parse(values[2]);
            int rent = int.Parse(values[3]);

            properties[id] = new Property(id, name, price, rent);
        }
    }

    public Property GetPropertyByID(int id)
    {
        return properties.ContainsKey(id) ? properties[id] : null;
    }
}

public class Property
{
    public int ID;
    public string Name;
    public int Price;
    public int Rent;

    public Property(int id, string name, int price, int rent)
    {
        ID = id;
        Name = name;
        Price = price;
        Rent = rent;
    }
}