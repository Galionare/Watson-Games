using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UtilityCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;

    public string Group;
    public bool Mortgaged = false;

    public int Cost;

    public bool Owned = false;
    public GameObject Owner;

    public GameObject BigCard;

    public int Position;
    private Dictionary<int, PropertyData> propertyData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateCard(Position);
    }
    public void CreateCard(int Position)
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData.TryGetValue(Position, out PropertyData data))
        {
            if (data.CanBeBought && (data.Group.Contains("Utilities")))
            {
                Name.text = $"{data.NameProperty}";
                Info1.text = $"{data.UtilRent1}";
                Info2.text = $"{data.UtilRent2}";

                Cost = data.Cost;
                Group = $"{data.Group}";
            }
        }
    }

    public void ShowFullCard()
    {
        GameObject Canvas = GameObject.Find("Canvas");

        GameObject CardButton = Instantiate(BigCard, Canvas.transform) as GameObject;
        int position = Position;

        Transform JustCard = CardButton.transform.GetChild(1);
        JustCard.GetComponent<FullUtilityCard>().CreateCard(position);

        FullUtilityCard pos = JustCard.GetComponent<FullUtilityCard>();
        pos.Position = position;
    }
}