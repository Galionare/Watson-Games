using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public static class CSVLoader2
{
    public static Dictionary<int, CardData> LoadCardData()
    {
        Dictionary<int, CardData> dataDictionary = new Dictionary<int, CardData>();

        string filePath = Path.Combine(Application.streamingAssetsPath, "PropertyTycoonCardData.csv");

        string[] lines = File.ReadAllLines(filePath);

        for (int i = 2; i < lines.Length; i++)// Skips first two rows
        {
            string[] values = lines[i].Split(',');

            if (string.IsNullOrWhiteSpace(values[0]))
                continue; // Skip invalid rows

            int position = 0;
            string cardType = "nothing";
            string description = "nothing";
            string action = "nothing";

            if (i >= 4 && i <= 21)
            {
                position = i;
                cardType = lines[2];
                description = values[0].Trim();
                action = values[3].Trim();
            }
            if (i >= 25 && i <= 41)
            {
                position = i;
                cardType = lines[25];
                description = values[0].Trim();
                action = values[3].Trim();
            }
           

            dataDictionary[position] = new CardData(position, cardType, description, action);
        }

        return dataDictionary;

    }

}