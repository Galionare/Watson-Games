using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPropery : MonoBehaviour
{
    public GameObject PropCard;
    public GameObject StatCard;
    public GameObject UtilCard;
    public GameObject Canvas;

    private Dictionary<int, PropertyData> propertyData;
    public int position;

    public void ShowProp(int position)
    {
        int Position = position;
        Debug.Log(Position);
        propertyData = CSVLoader.LoadPropertyData();
        if (propertyData.TryGetValue(Position, out PropertyData data))
        {

            if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue")))
            {
                GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;
                Card1.GetComponent<StreetCard>().CreateCard(Position);
                StreetCard pos = Card1.GetComponent<StreetCard>();
                pos.Position = Position;
            }
            if (data.CanBeBought && (data.Group.Contains("Station")))
            {
                GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                Card2.GetComponent<StationCard>().CreateCard(Position);
                StationCard pos = Card2.GetComponent<StationCard>();
                pos.Position = Position;
            }

            if (data.CanBeBought && (data.Group.Contains("Utilities")))
            {
                GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                Card3.GetComponent<UtilityCard>().CreateCard(Position);
                UtilityCard pos = Card3.GetComponent<UtilityCard>();
                pos.Position = Position;
            }
        }
    }
}
