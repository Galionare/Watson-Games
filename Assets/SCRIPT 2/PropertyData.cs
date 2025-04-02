using UnityEngine;

public class PropertyData
{
    public int Position;
    public string NameProperty;
    public string Group;
    public string Action;
    public bool CanBeBought;
    public int Cost;
    public int Rent;
    public int[] Houses;

    public PropertyData(int position, string nameproperty, string group, string action, bool canBeBought, int cost, int rent, int[] houses)
    {
        Position = position;
        NameProperty = nameproperty;
        Group = group;
        Action = action;
        CanBeBought = canBeBought;
        Cost = cost;
        Rent = rent;
        Houses = houses;
    }
}