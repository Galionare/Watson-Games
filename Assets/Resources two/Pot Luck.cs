using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PotLuck : MonoBehaviour
{
    public TextMeshProUGUI Info;
    public int Position = 5; // Random.Range(4, 22);
    private Dictionary<int, CardData> cardData;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateCard(Position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateCard(int Position)
    {
        cardData = CSVLoader2.LoadCardData();

        if (cardData.TryGetValue(Position, out CardData data))
        {

            Info.text = $"{data.Description}";
        }
    }
}
