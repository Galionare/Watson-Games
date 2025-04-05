using UnityEngine;
using System;
using System.Collections.Generic;

public class AllCards : MonoBehaviour
{
    public GameObject PropCard;
    public GameObject StatCard;
    public GameObject UtilCard;
    public GameObject Canvas;

    public GameObject ViewButton;
    public GameObject BackButton;

    private List<GameObject> spawnedCards = new List<GameObject>();


    public int position;
    private Dictionary<int, PropertyData> propertyData;

    public void ViewCards()
    {

        propertyData = CSVLoader.LoadPropertyData();
        int Counter1 = 0;
        int Counter2 = 0;
        int Counter3 = 0;

        for (int i = 1; i <= 40; i++)
        {
            int Position = i;
            if (propertyData.TryGetValue(Position, out PropertyData data))
            {
                
                if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue")))
                {
                    GameObject Card1 = Instantiate(PropCard, Canvas.transform) as GameObject;
                    Card1.GetComponent<StreetCard>().CreateCard(Position);
                    StreetCard pos = Card1.GetComponent<StreetCard>();
                    pos.Position = Position;
                    


                    if (Counter1 <= 7)
                    {
                        RectTransform rectTransform = Card1.GetComponent<RectTransform>();
                        rectTransform.anchoredPosition = new Vector2(-600, 320-(Counter1*100));
                    }

                    else if(Counter1 <= 13)
                    {
                        RectTransform rectTransform = Card1.GetComponent<RectTransform>();
                        rectTransform.anchoredPosition = new Vector2(-300, 320 - ((Counter1-8) * 100));
                    }
                    else
                    {
                        RectTransform rectTransform = Card1.GetComponent<RectTransform>();
                        rectTransform.anchoredPosition = new Vector2(0, 320 - ((Counter1 - 14) * 100));
                    }
                    spawnedCards.Add(Card1);
                    Counter1++;
                }

                if (data.CanBeBought && (data.Group.Contains("Station")))
                {
                    GameObject Card2 = Instantiate(StatCard, Canvas.transform) as GameObject;
                    Card2.GetComponent<StationCard>().CreateCard(Position);
                    RectTransform rectTransform = Card2.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(350, 320 - (Counter2 * 200));
                    spawnedCards.Add(Card2);
                    Counter2++;
                    
                }

                if (data.CanBeBought && (data.Group.Contains("Utilities")))
                {
                    GameObject Card3 = Instantiate(UtilCard, Canvas.transform) as GameObject;
                    Card3.GetComponent<UtilityCard>().CreateCard(Position);
                    RectTransform rectTransform = Card3.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(700, 320 - (Counter3 * 200));
                    spawnedCards.Add(Card3);
                    Counter3++;
                }
            }
        }
        GameObject Button1 = ViewButton;
        Button1.GetComponent<ButtonSc>().HideButton();

        GameObject Button2 = BackButton;
        Button2.GetComponent<BackButton>().ShowButton();
    }
    public void Back()
    {
        foreach (GameObject card in spawnedCards)
        {
            Destroy(card);
        }

        spawnedCards.Clear();

        GameObject Button1 = ViewButton;
        Button1.GetComponent<ButtonSc>().ShowButton();

        GameObject Button2 = BackButton;
        Button2.GetComponent<BackButton>().HideButton();
    }

}
