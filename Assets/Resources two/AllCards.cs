using UnityEngine;
using System;
using System.Collections.Generic;

public class AllCards : MonoBehaviour
{
    public GameObject PropCard;
    public GameObject StatCard;
    public GameObject UtilCard;
    public GameObject Canvas;
    public StreetCard StreetCard;
    public StationCard StationCard;
    public UtilityCard UtilityCard;

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
                    StreetCard.CreateCard(i);

                    GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;

                    Card1.GetComponent<StreetCard>().CreateCard(Position);

                //    ScriptName sn = gameObject.GetComponent<ScriptName>()
               //     sn.DoSomething();

                }

                if (data.CanBeBought && (data.Group.Contains("Station")))
                {
                    StationCard.CreateCard(i);
                    GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                }

                if (data.CanBeBought && (data.Group.Contains("Utilities")))
                {
                    UtilityCard.CreateCard(i);
                    GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                }
            }
        }
    }
}
