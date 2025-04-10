using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FullUtilityCard : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;

    public string Group;
    public int Cost;

    public TextMeshProUGUI Name2;
    public TextMeshProUGUI Mortgage;
    public TextMeshProUGUI ReturnMortgage;

    public bool Mortgaged = false;

    public bool Owned = false;
    public GameObject Owner;

    public Transform Front;
    public Transform Back;

    private bool Flipped = false;

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

                Group = $"{data.Group}";
                Cost = data.Cost;

                Name2.text = $"{data.NameProperty}";
                Mortgage.text = $"{data.Mortgage}";
                ReturnMortgage.text = $"{data.ReturnMotrtgage}";
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