using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class StreetCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Rent;
    public TextMeshProUGUI RentFull;
    public TextMeshProUGUI Rent1H;
    public TextMeshProUGUI Rent2H;
    public TextMeshProUGUI Rent3H;
    public TextMeshProUGUI Rent4H;
    public TextMeshProUGUI RentHotel;

    public Image EmptyCard;
    public Sprite BrownProp;
    public Sprite BlueProp;
    public Sprite RedProp;
    public Sprite PurpleProp;
    public Sprite OrangeProp;
    public Sprite YellowProp;
    public Sprite GreenProp;
    public Sprite DeepBlueProp;

    public int Position = 4;
    private Dictionary<int, PropertyData> propertyData;


   /* void OnEnable()
    {
        // Subscribe to position updates
        AllCards.OnPositionUpdated += LoadData;
    }

    void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        AllCards.OnPositionUpdated -= LoadData;
    }*/
    void Start()
    {
        propertyData = CSVLoader.LoadPropertyData();

        //    Position = GetComponent<AllCards>().position;
        //   Position = newPosition;
        Debug.Log(Position+"Street");

        if (propertyData.TryGetValue(Position, out PropertyData data))
        {
            if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue")))
            {

                Name.text = $"{data.NameProperty}";
                Rent.text = $"{data.Rent}";
                RentFull.text = $"{data.FullRent}";
                Rent1H.text = $"{data.Houses[0]}";
                Rent2H.text = $"{data.Houses[1]}";
                Rent3H.text = $"{data.Houses[2]}";
                Rent4H.text = $"{data.Houses[3]}";
                RentHotel.text = $"{data.Houses[4]}";

                SpriteChanger();
            }
        }
    }


    public void SpriteChanger()
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData.TryGetValue(Position, out PropertyData data))
        {

            if (data.Group.Contains("Brown"))
            {
                EmptyCard.sprite = BrownProp;
            }
            else if (data.Group.Contains("Red"))
            {
                EmptyCard.sprite = RedProp;
            }
            else if (data.Group.Contains("Blue"))
            {
                EmptyCard.sprite = BlueProp;
            }
            else if (data.Group.Contains("Purple"))
            {
                EmptyCard.sprite = PurpleProp;
            }
            else if (data.Group.Contains("Orange"))
            {
                EmptyCard.sprite = OrangeProp;
            }
            else if (data.Group.Contains("Yellow"))
            {
                EmptyCard.sprite = YellowProp;
            }
            else if (data.Group.Contains("Green"))
            {
                EmptyCard.sprite = GreenProp;
            }
            else if (data.Group.Contains("Deep blue"))
            {
                EmptyCard.sprite = DeepBlueProp;
            }
        }
    }
}
