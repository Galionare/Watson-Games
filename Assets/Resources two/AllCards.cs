using UnityEngine;
using System;
using System.Collections.Generic;

public class AllCards : MonoBehaviour
{
    public GameObject PropCard;
    public GameObject StatCard;
    public GameObject UtilCard;
    public GameObject Canvas;

    // to define when the variable position gets updates
    //public static event Action<int> OnPositionUpdated;


    public int position;
    private Dictionary<int, PropertyData> propertyData;

    public void ViewCards()
    {
        propertyData = CSVLoader.LoadPropertyData();

        for (int i = 1; i <= 40; i++)
        {
            int Position = i;
 
            if (propertyData.TryGetValue(Position, out PropertyData data))
            {
                
                if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue")))
                {
                    GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;
                    Card1.GetComponent<StreetCard>().CreateCard(Position);

                }

                if (data.CanBeBought && (data.Group.Contains("Station")))
                {
                    GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                    Card2.GetComponent<StationCard>().CreateCard(Position);

                }

                if (data.CanBeBought && (data.Group.Contains("Utilities")))
                {
                    GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                    Card3.GetComponent<UtilityCard>().CreateCard(Position);

                }
            }
        }
    }
}
