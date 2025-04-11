using UnityEngine;
using System.Collections.Generic;

public class Testing : MonoBehaviour
{
    public GameObject PropCard;
    public GameObject StatCard;
    public GameObject UtilCard;
    public GameObject Canvas;
    public GameObject PlayerObj;

    public List<GameObject> Players = new List<GameObject>();

    public List<List<GameObject>> AllProperties = new List<List<GameObject>>();
    public List<GameObject> StreetProperties = new List<GameObject>();
    public List<GameObject> BrownProperties = new List<GameObject>();
    public List<GameObject> StationProperties = new List<GameObject>();
    public List<GameObject> UtilityProperties = new List<GameObject>();
    public List<int> Brown = new List<int>();
    public List<int> Blue = new List<int>();
    public List<int> Purple = new List<int>();
    public List<int> Orange = new List<int>();
    public List<int> Red = new List<int>();
    public List<int> Yellow = new List<int>();
    public List<int> Green = new List<int>();
    public List<int> DeepBlue = new List<int>();

    public int NumberOfPlayers;

    private Dictionary<int, PropertyData> propertyData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void CollectProperties()
    {
        int Counter1 = 0;
        int Counter2 = 0;
        int Counter3 = 0;
        AllProperties.Add(StreetProperties);
        AllProperties.Add(StationProperties);
        AllProperties.Add(UtilityProperties);
        for (int i = 1; i <= 40; i++)
        {
            int Position = i;
            if (propertyData.TryGetValue(Position, out PropertyData data))
            {
                if (data.CanBeBought)
                {


                    if (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue"))
                    {

                        GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;
                        Card1.GetComponent<StreetCard>().CreateCard(Position);
                        StreetCard pos = Card1.GetComponent<StreetCard>();
                        pos.Position = Position;
                        Counter1++;
                        Card1.name = "Street" + Counter1;
                        if (data.Group.Contains("Brown"))
                        {
                            Brown.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        if (data.Group.Contains("Blue"))
                        {
                            Blue.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        if (data.Group.Contains("Purple"))
                        {
                            Purple.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        if (data.Group.Contains("Orange"))
                        {
                            Orange.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        if (data.Group.Contains("Red"))
                        {
                            Red.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        if (data.Group.Contains("Yellow"))
                        {
                            Yellow.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        if (data.Group.Contains("Green"))
                        {
                            Green.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        if (data.Group.Contains("DeepBlue"))
                        {
                            DeepBlue.Add(Card1.GetComponent<StreetCard>().Position);
                        }
                        StreetProperties.Add(Card1);
                    }

                    if ((data.Group.Contains("Station")))
                    {
                        GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                        Card2.GetComponent<StationCard>().CreateCard(Position);
                        StationCard pos = Card2.GetComponent<StationCard>();
                        pos.Position = Position;
                        Counter2++;
                        Card2.name = "Station" + Counter2;
                        StationProperties.Add(Card2);

                    }

                    if ((data.Group.Contains("Utilities")))
                    {
                        GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                        Card3.GetComponent<UtilityCard>().CreateCard(Position);
                        UtilityCard pos = Card3.GetComponent<UtilityCard>();
                        pos.Position = Position;
                        Counter3++;
                        Card3.name = "Utility" + Counter3;
                        UtilityProperties.Add(Card3);
                    }
                }
            }
        }
    }
    public void CollectPLayers()
    {
        for (int i = 0; i <NumberOfPlayers; i++)
        {
            GameObject Player = Instantiate(PlayerObj) as GameObject;
            Player.name = "Player" + i;
            Players.Add(Player);
        }
    }
}