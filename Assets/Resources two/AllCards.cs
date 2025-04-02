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
            int position = i;
        //    Debug.Log(i);
            //to notify listeners if position changes
       //     OnPositionUpdated?.Invoke(position);S

            if (propertyData.TryGetValue(position, out PropertyData data))
            {
                Debug.Log(i);
                if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue")))
                {
                    
                    GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;
                }

                if (data.CanBeBought && (data.Group.Contains("Station")))
                {
                    
                    GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                }

                if (data.CanBeBought && (data.Group.Contains("Utilities")))
                {
                    
                    GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                }
            }
        }
    }
}
