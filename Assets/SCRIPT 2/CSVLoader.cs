using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public static class CSVLoader
{
    public static Dictionary<int, PropertyData> LoadPropertyData()
    {
        Dictionary<int, PropertyData> dataDictionary = new Dictionary<int, PropertyData>();

        string filePath = Path.Combine(Application.streamingAssetsPath, "PropertyTycoonBoardData.csv");

        string[] lines = File.ReadAllLines(filePath);

        for (int i = 1; i < lines.Length; i++) // Skip header row
        {
            string[] values = lines[i].Split(',');

            if (values.Length < 8 || string.IsNullOrWhiteSpace(values[0]))
                continue; // Skip invalid rows

            int position;
            if (!int.TryParse(values[0], out position))
                continue; // Skip non-numeric rows (like headers)

            string nameproperty = values[1].Trim();
            string group = values[3].Trim();
            string action = values[4].Trim();
            bool canBeBought = values[5].Trim().ToLower() == "yes";

            int price = 0, rent = 0;
            int[] houses = new int[5]; // 1 house to 1 hotel

            if (canBeBought)
            {
                int.TryParse(values[7], out price);
                int.TryParse(values[8], out rent);

                for (int j = 0; j < 5; j++) // Rent values from columns 9-13
                {
                    int.TryParse(values[10 + j], out houses[j]);
                }
            }
            dataDictionary[position] = new PropertyData(position,nameproperty, group, action, canBeBought, price, rent, houses);
        }

        return dataDictionary;

    }
}