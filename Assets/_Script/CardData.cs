using UnityEngine;

public class CardData
{
    public int Position;
    public string CardType;
    public string Description;
    public string Action;
    public CardData(int position, string cardType, string description, string action)
    {
        Position = position;
        CardType = cardType;
        Description = description;
        Action = action;
    }
}
