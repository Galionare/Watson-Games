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

        for (int i = 2; i < lines.Length; i++)
        { 
            string[] values = lines[i].Split(';');

            if (values.Length < 4 || string.IsNullOrWhiteSpace(values[0]))  //values.Length < 4 || 
                continue;



            int position = i+1;
            string cardType = "nothing";
            string description = values[0].Trim();
            string action = values[3].Trim();

            if (5 <= i && i <= 21)
            {
              //  for (int k = 2; k < lines.Length; k++)
             //   {
                    string[] value1 = lines[2].Split(';');
                    cardType = value1[0];
             //   }
            }
            if (25 <= i && i <= 41)
            {
             //   for (int k = 2; k < lines.Length; k++)
              //  {
                    string[] value1 = lines[23].Split(';');
                    cardType = value1[0];
             //   }
            }


            dataDictionary[position] = new CardData(position, cardType, description, action);
        }

        return dataDictionary;

    }

}