using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PotLuck : MonoBehaviour
{
    public TextMeshProUGUI Type;
    public TextMeshProUGUI Info;

    public int Position = 10; // Random.Range(4, 22);
    private Dictionary<int, CardData> cardData;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateCard(Position);
    }
    public void CreateCard(int Position)
    {
        cardData = CSVLoader2.LoadCardData();

        if (cardData.TryGetValue(Position, out CardData data))
        {
            Type.text = $"{data.CardType}";
            Info.text = $"{data.Description}";
        }
    }
}
