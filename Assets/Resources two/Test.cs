using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
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

    private int position = 6;
    private Dictionary<int, PropertyData> propertyData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        /*if (int.TryParse(gameObject.name, out position))
        {
            propertyData = CSVLoader.LoadPropertyData();
        }*/
        propertyData = CSVLoader.LoadPropertyData();

        if (int.TryParse(gameObject.name, out position) && PropertyData.TryGetValue(position, out PropertyData data))
        {

        }


       // foreach (var entry in propertyData)
       // {
       //     PropertyData data = entry.Value;
            Name.text = $"{data.NameProperty}";

            if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep Blue")))
            {
             //   Debug.Log($"ID: {data.Position}, Name: {data.NameProperty}, Group: {data.Group}, Price: {data.Price}, Rent: {data.Rent}, Full Rent: {data.FullRent}, Rent with houses: {string.Join(", ", data.Houses)}");

                Name.text = $"{data.NameProperty}";
                Rent.text = $"{data.Rent.ToString()}";
                RentFull.text = $"{data.FullRent}";
                Rent1H.text = $"{data.Houses[0].ToString()}";
                Rent2H.text = $"{data.Houses[1].ToString()}";
                Rent3H.text = $"{data.Houses[2].ToString()}";
                Rent4H.text = $"{data.Houses[3].ToString()}";
                RentHotel.text = $"{data.Houses[4].ToString()}";

                SpriteChanger();
            }
      //  }
    }


    public void SpriteChanger()
    {
        if (int.TryParse(gameObject.name, out position))
        {
            propertyData = CSVLoader.LoadPropertyData();
        }
        foreach (var entry in propertyData)
        {
            PropertyData data = entry.Value;
        

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
            else if (data.Group.Contains("Deep Blue"))
            {
                EmptyCard.sprite = DeepBlueProp;
            }
        }
    }
}
