using UnityEngine;

public class PropertyData
{
    public int Position;
    public string NameProperty;
    public string Group;
    public string Action;
    public bool CanBeBought;
    public int Price;
    public int Rent;
    public int[] Houses;

    public PropertyData(int position, string nameproperty, string group, string action, bool canBeBought, int price, int rent, int[] houses)
    {
        Position = position;
        NameProperty = nameproperty;
        Group = group;
        Action = action;
        CanBeBought = canBeBought;
        Price = price;
        Rent = rent;
        Houses = houses;
    }
}