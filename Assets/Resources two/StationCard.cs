using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class StationCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;
    public TextMeshProUGUI Info3;
    public TextMeshProUGUI Info4;

    public bool Owned = false;

    public GameObject BigCard;

    public int Position;

    private Dictionary<int, PropertyData> propertyData;
    void Start()
    {
        CreateCard(Position);
    }
    public void CreateCard(int Position)
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData.TryGetValue(Position, out PropertyData data))
        {
            if (data.CanBeBought && (data.Group.Contains("Station")))
            {
                Name.text = $"{data.NameProperty}";
                Info1.text = $"{data.StatRent1}";
                Info2.text = $"{data.StatRent2}";
                Info3.text = $"{data.StatRent3}";
                Info4.text = $"{data.StatRent4}";
            }
        }
    }
    public void ShowFullCard()
    {
        GameObject Canvas = GameObject.Find("Canvas");

        GameObject CardButton = Instantiate(BigCard, Canvas.transform) as GameObject;
        int position = Position;

        Transform JustCard = CardButton.transform.GetChild(1);
        JustCard.GetComponent<FullStationCard>().CreateCard(position);

        FullStationCard pos = JustCard.GetComponent<FullStationCard>();
        pos.Position = position;
    }
}
