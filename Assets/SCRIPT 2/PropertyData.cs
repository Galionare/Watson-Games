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
    public int FullRent;
    public int[] Houses;
    public string StatRent1;
    public string StatRent2;
    public string StatRent3;
    public string StatRent4;
    public string UtilRent1;
    public string UtilRent2;
    public int Mortgage;
    public double ReturnMotrtgage;

    public PropertyData(int position, string nameproperty, string group, string action, bool canBeBought, int price, int mortgage, double returnMortgage, int rent, int fullRent,  int[] houses, string statRent1, string statRent2, string statRent3, string statRent4, string utilRent1, string utilRent2)
    {
        Position = position;
        NameProperty = nameproperty;
        Group = group;
        Action = action;
        CanBeBought = canBeBought;
        Price = price;
        Rent = rent;
        FullRent = fullRent;
        Houses = houses;
        StatRent1 = statRent1;
        StatRent2 = statRent2;
        StatRent3 = statRent3;
        StatRent4 = statRent4;
        UtilRent1 = utilRent1;
        UtilRent2 = utilRent2;
        Mortgage = mortgage;
        ReturnMotrtgage = returnMortgage;
    }
}