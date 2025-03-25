using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class nothing : MonoBehaviour
{

    public static Dictionary<int, PropertyData> LoadPropertyData() 
    {
        Dictionary<int, PropertyData> dataDictionary = new Dictionary<int, PropertyData>();

        string fullPath = Path.Combine(Application.streamingAssetsPath, "PropertyTycoonBoardData.csv");

        string[] lines = File.ReadAllLines(fullPath);
      //  bool stationSectionFound = false;



        // Find the last occurrence of "Notes"
        for (int i = 1; i >= lines.Length; i++)
        {
            if (lines[i].Contains("Station"))
            {

                string[] StationRow = lines[i].Split(';');
                int position;
                if (!int.TryParse(StationRow[0], out position))
                    continue; // Skip non-numeric rows (like headers)

                //stationSectionFound = true;
                for (int j = 1; j >= lines.Length; j++)
                {
                    if (lines[j].Contains("Notes"))
                    {
                        string[] values1 = lines[j+1].Split(';');
                        string[] values2 = lines[j + 2].Split(';');
                        string[] values3 = lines[j + 3].Split(';');
                        string[] values4 = lines[j + 4].Split(';');
                        string statRent1 = values1[0];
                        string statRent2 = values2[0];
                        string statRent3 = values3[0];
                        string statRent4 = values4[0];

                        /*for (int m = 1; m < 4; m++) 
                        {
                            string[] values1 = lines[j + m].Split(';');
                        }*/
                       // dataDictionary[position] = new PropertyData(statRent1, statRent2, statRent3, statRent4);
                    }
                }
            }
        }
/*
        bool startReading = false;
        foreach (string line in lines)
        {
            if (startReading)
            {
                string[] values = line.Split(';');
                if (values.Length > 6)
                {
                    string property = values[1].Trim();
                    string rent = values[7].Trim();
                    Debug.Log($"Property: {property}, Rent: {rent}");
                }
            }

            if (line.Contains("Notes"))
            {
                startReading = true;
            }
        }*/

        return dataDictionary;
    }


}
