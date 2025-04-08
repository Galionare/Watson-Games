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

        for (int i = 5; i < lines.Length; i++)
        { 
            string[] values = lines[i].Split(',');

            if (values.Length < 4 || string.IsNullOrWhiteSpace(values[0]))
                continue;


            int position = i;
            string cardType = "nothing";
            string description = "nothing";
            string action = "nothing";
           // description = values[0].Trim();
          //  action = values[3].Trim();

            /*if (values.Length < 4)
            {
                description = values[0];
                action = values[3];

                if (5 >= i && i <= 21)
                {
                    cardType = lines[2].Split(',')[0];
                }
                if (25 >= i && i <= 41)
                {
                    cardType = lines[25].Split(',')[0];
                }
            }*/


            dataDictionary[position] = new CardData(position, cardType, description, action);
        }

        return dataDictionary;

    }

}