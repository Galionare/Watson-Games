using System.Collections.Generic;
using UnityEngine;

public class ShowProperty : MonoBehaviour
{
     public GameObject PropCard;
     public GameObject StatCard;
     public GameObject UtilCard;
     public GameObject Canvas;

     //public GameObject PotKNokss;

     //PotKnock potKnock;

     private Dictionary<int, PropertyData> propertyData;

    private void Start()
    {
        //potKnock = FindFirstObjectByType<PotKnock>();
    }

    public void ShowProp(int position)
     {
         int Position = position + 1;
         Debug.Log(Position);
         propertyData = CSVLoader.LoadPropertyData();
         if (propertyData.TryGetValue(Position, out PropertyData data))
         {

             if (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue"))
             {
                 GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;
                 Card1.GetComponentInChildren<FullStreetCard>().CreateCard(Position);
                 FullStreetCard pos = Card1.GetComponentInChildren<FullStreetCard>();
                 pos.Position = Position;
             }
             if (data.Group.Contains("Station"))
             {
                 GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                 Card2.GetComponentInChildren<FullStationCard>().CreateCard(Position);
                 FullStationCard pos = Card2.GetComponentInChildren<FullStationCard>();
                 pos.Position = Position;

             }

             if (data.Group.Contains("Utilities"))
             {
                 GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                 Card3.GetComponentInChildren<FullUtilityCard>().CreateCard(Position);
                 FullUtilityCard pos = Card3.GetComponentInChildren<FullUtilityCard>();
                 pos.Position = Position;

             }
            /* if (data.NameProperty.Contains("Pot Luck"))
             {
                GameObject POT = Instantiate(PotKNokss, Canvas.transform) as GameObject;
                POT.GetComponentInChildren<FullUtilityCard>().CreateCard(Position);

            }
            if (data.NameProperty.Contains("Opportunity Knocks"))
            {
                GameObject KNO = potKnock.KnockPile[Random.Range(0, 16)];
                Instantiate(KNO, Canvas.transform);
            }*/
        }
     }
 
}