using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FullStreetCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Rent;
    public TextMeshProUGUI RentFull;
    public TextMeshProUGUI Rent1H;
    public TextMeshProUGUI Rent2H;
    public TextMeshProUGUI Rent3H;
    public TextMeshProUGUI Rent4H;
    public TextMeshProUGUI RentHotel;

    public string Group;
    public int Cost;
    public int NumOfHouses;

    public TextMeshProUGUI Name2;
    public TextMeshProUGUI Mortgage;
    public TextMeshProUGUI ReturnMortgage;

    public bool Mortgaged = false;

    public Image EmptyCard;
    public Sprite BrownProp;
    public Sprite BlueProp;
    public Sprite RedProp;
    public Sprite PurpleProp;
    public Sprite OrangeProp;
    public Sprite YellowProp;
    public Sprite GreenProp;
    public Sprite DeepBlueProp;

    public bool Owned = false;
    public GameObject Owner;

    public TextMeshProUGUI CostHouse;
    public TextMeshProUGUI CostHotel;

    public Transform Front;
    public Transform Back;


    public int Position;
    private Dictionary<int, PropertyData> propertyData;

    private bool Flipped = false;


    void Start()
    {
        CreateCard(Position);
    }


    public void CreateCard(int Position)
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData.TryGetValue(Position, out PropertyData data))
        {
            if (data.CanBeBought && (data.Group.Contains("Brown") || data.Group.Contains("Blue") || data.Group.Contains("Purple") || data.Group.Contains("Orange") || data.Group.Contains("Red") || data.Group.Contains("Yellow") || data.Group.Contains("Green") || data.Group.Contains("Deep blue")))
            {
                int Position1 = Position;
                SpriteChanger(Position1);

                Name.text = $"{data.NameProperty}";
                Rent.text = $"{data.Rent}";
                RentFull.text = $"{data.FullRent}";
                Rent1H.text = $"{data.Houses[0]}";
                Rent2H.text = $"{data.Houses[1]}";
                Rent3H.text = $"{data.Houses[2]}";
                Rent4H.text = $"{data.Houses[3]}";
                RentHotel.text = $"{data.Houses[4]}";

                Group = $"{data.Group}";
                Cost = data.Cost;

                CostHouse.text = $"{data.CostHouse}";
                CostHotel.text = $"{data.CostHotel}";

                Name2.text = $"{data.NameProperty}";
                Mortgage.text = $"{data.Mortgage}";
                ReturnMortgage.text = $"{data.ReturnMotrtgage}";

            }
        }
    }

    public void SpriteChanger(int Position)
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
    public void FlipCard()
    {
        Flipped = !Flipped;
        transform.DORotate(new(0, Flipped ? 0f : 180f, 0), 0.25f);

        Invoke(nameof(ChangeSiblingIndex), 0.08f);
        
    }
    void ChangeSiblingIndex()
    {
        if (Flipped)
        {
            Transform Front1 = Front;
            Front1.SetSiblingIndex(1);
        }
        if (!Flipped)
        {
            Transform Back1 = Back;
            Back1.SetSiblingIndex(1);
        }
    }
}
