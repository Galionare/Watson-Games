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

    public void ShowProp(int position)
    {
        int Position = position + 1;
        Debug.Log(Position);
        propertyData = CSVLoader.LoadPropertyData();
        if (propertyData.TryGetValue(Position, out PropertyData data))
        {

            if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue")))
            {
                GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;
                Card1.GetComponentInChildren<FullStreetCard>().CreateCard(Position);
                FullStreetCard pos = Card1.GetComponentInChildren<FullStreetCard>();
                pos.Position = Position;
            }
            if (data.CanBeBought && (data.Group.Contains("Station")))
            {
                GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                Card2.GetComponentInChildren<FullStationCard>().CreateCard(Position);
                FullStationCard pos = Card2.GetComponentInChildren<FullStationCard>();
                pos.Position = Position;

            }

            if (data.CanBeBought && (data.Group.Contains("Utilities")))
            {
                GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                Card3.GetComponentInChildren<FullUtilityCard>().CreateCard(Position);
                FullUtilityCard pos = Card3.GetComponentInChildren<FullUtilityCard>();
                pos.Position = Position;

            }
        }
    }
}
