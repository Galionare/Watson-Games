using System.Collections.Generic;
using System.IO;
using UnityEngine;


public static class CSVLoader
{

    public static Dictionary<int, PropertyData> LoadPropertyData()
    {
        Dictionary<int, PropertyData> dataDictionary = new Dictionary<int, PropertyData>();

        string filePath = Path.Combine(Application.streamingAssetsPath, "PropertyTycoonBoardData.csv");

        string[] lines = File.ReadAllLines(filePath);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            if (values.Length < 8 || string.IsNullOrWhiteSpace(values[0]))
                continue; // Skip invalid rows

            string nameproperty = values[1].Trim();
            string group = values[3].Trim();
            string action = values[4].Trim();
            bool canBeBought = values[5].Trim().ToLower() == "yes";

            int cost = 0, rent = 0;
            int fullRent = 0;
            int mortgage = 0;
            double returnMortgage = 0;
            int[] houses = new int[5]; // 1 house to 1 hotel
            int position;

            //fing the rent of stations only
            string statRent1 = "nothing";
            string statRent2 = "nothing";
            string statRent3 = "nothing";
            string statRent4 = "nothing";

            //find the rent of utilities only
            string utilRent1 = "nothing";
            string utilRent2 = "nothing";

            string costHouse = "nothing";
            string costHotel = "nothing";

            if (!int.TryParse(values[0], out position))
                continue; // Skip non-numeric rows (like headers)

            if (canBeBought)
            {
                int.TryParse(values[7], out cost);
                mortgage = cost / 2;
                returnMortgage = mortgage * (1.1);
            
                if (group.Contains("Brown") || group.Contains("Blue") || group.Contains("Purple") || group.Contains("Orange") || group.Contains("Red") || group.Contains("Yellow") || group.Contains("Green") || group.Contains("Deep blue"))
                {

                    int.TryParse(values[8], out rent);
                    fullRent = rent * 2;


                    for (int j = 0; j < 5; j++) // Rent values from columns 9-13
                    {
                        int.TryParse(values[10 + j], out houses[j]);
                    }
                    if (group.Contains("Blue") || group.Contains("Brown"))
                    {
                        for (int p = lines.Length - 1; p >= 0; p--)
                        {
                            if (lines[p].Contains("Brown, Blue"))
                            {
                                string[] values1 = lines[p].Split(',');

                                costHouse = values1[11];
                                costHotel = values1[12];
                                //   int.TryParse(values[p+1], out CostHouse);
                                //   int.TryParse(values[p + 1], out CostHotel);
                            }
                        }
                    }
                    if (group.Contains("Purple") || group.Contains("Orange"))
                    {
                        for (int p = lines.Length - 1; p >= 0; p--)
                        {
                            if (lines[p].Contains("Purple, Orange"))
                            {
                                string[] values1 = lines[p].Split(',');

                                costHouse = values1[11];
                                costHotel = values1[12];
                                //   int.TryParse(values[p+1], out CostHouse);
                                //   int.TryParse(values[p + 1], out CostHotel);
                            }
                        }
                    }
                    if (group.Contains("Red") || group.Contains("Yellow"))
                    {
                        for (int p = lines.Length - 1; p >= 0; p--)
                        {
                            if (lines[p].Contains("Red, Yellow"))
                            {
                                string[] values1 = lines[p].Split(',');

                                costHouse = values1[11];
                                costHotel = values1[12];
                                //   int.TryParse(values[p+1], out CostHouse);
                                //   int.TryParse(values[p + 1], out CostHotel);
                            }
                        }
                    }
                    if (group.Contains("Green") || group.Contains("Deep blue"))
                    {
                        for (int p = lines.Length - 1; p >= 0; p--)
                        {
                            if (lines[p].Contains("Green, Deep blue"))
                            {
                                string[] values1 = lines[p].Split(',');

                                costHouse = values1[11];
                                costHotel = values1[12];
                                //   int.TryParse(values[p+1], out CostHouse);
                                //   int.TryParse(values[p + 1], out CostHotel);
                            }
                        }
                    }
                }

                if (group.Contains("Station"))
                {
                    for (int m = lines.Length - 1; m >= 0; m--) // Looks for the last occurance of Notes
                    {
                        if (lines[m].Contains("Notes"))
                        {
                            // and gets 
                            string[] values1 = lines[m + 3].Split(',');
                            string[] values2 = lines[m + 4].Split(',');
                            string[] values3 = lines[m + 5].Split(',');
                            string[] values4 = lines[m + 6].Split(',');
                            statRent1 = values1[0] + values1[1];
                            statRent2 = values2[0] + values2[1];
                            statRent3 = values3[0] + values3[1];
                            statRent4 = values4[0] + values4[1];
                            break;
                        }
                    }
                }

                if (group.Contains("Utilities"))
                {
                    for (int k = lines.Length - 1; k >= 0; k--)
                    {
                        if (lines[k].Contains("Notes"))
                        {
                            string[] values1 = lines[k + 1].Split(',');
                            string[] values2 = lines[k + 2].Split(',');
                            utilRent1 = values1[0] + values1[1];
                            utilRent2 = values2[0] + values2[1];
                            break;
                        }
                    }
                }
            }

            dataDictionary[position] = new PropertyData(position,nameproperty, group, action, canBeBought, cost, mortgage, returnMortgage, rent, fullRent, houses, statRent1, statRent2, statRent3, statRent4, utilRent1, utilRent2, costHouse, costHotel);
        }

        return dataDictionary;

    }
 
}