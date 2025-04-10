using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class SquareData : MonoBehaviour
{
    private int position;
    private Dictionary<int, PropertyData> propertyData;
    [SerializeField] private TextMeshPro Name;
    [SerializeField] private TextMeshPro Cost;
    [SerializeField] private TextMeshPro Action;

    public Material BrownProp;
    public Material BlueProp;
    public Material RedProp;
    public Material PurpleProp;
    public Material OrangeProp;
    public Material YellowProp;
    public Material GreenProp;
    public Material DeepBlueProp;
    public Material StationProp;
    public Material UtilitiesProp;


    void Start()
    {
        propertyData = CSVLoader.LoadPropertyData();
        if (int.TryParse(gameObject.name, out position) && propertyData.TryGetValue(position, out PropertyData data))
        {
            DisplayTileData(data);
            SpriteChanger(position);
        }
       
    }
    private void DisplayTileData(PropertyData data)
    {
        Name.text = $"{data.NameProperty}";
        if (data.CanBeBought)
        {
            Cost.text = $"�{data.Cost}";
            Cost.gameObject.SetActive(true);
            Action.gameObject.SetActive(false);
        }
        else
        {
            Action.text = $"{data.Action}";
            Cost.gameObject.SetActive(false);
            Action.gameObject.SetActive(true);
        }
    }
    public void SpriteChanger(int Position)
    {
        propertyData = CSVLoader.LoadPropertyData();

        if (propertyData.TryGetValue(Position, out PropertyData data))
        {
            Renderer renderer = GetComponent<Renderer>();
            if (data.Group.Contains("Brown"))
            {
                renderer.material = BrownProp;
            }
            else if (data.Group.Contains("Red"))
            {
                renderer.material = RedProp;
            }
            else if (data.Group.Contains("Blue"))
            {
                renderer.material = BlueProp;
            }
            else if (data.Group.Contains("Purple"))
            {
                renderer.material = PurpleProp;
            }
            else if (data.Group.Contains("Orange"))
            {
                renderer.material = OrangeProp;
            }
            else if (data.Group.Contains("Yellow"))
            {
                renderer.material = YellowProp;
            }
            else if (data.Group.Contains("Green"))
            {
                renderer.material = GreenProp;
            }
            else if (data.Group.Contains("Deep blue"))
            {
                renderer.material = DeepBlueProp;
            }
            else if (data.Group.Contains("Station"))
            {
                renderer.material = StationProp;
            }
            else if (data.Group.Contains("Utilities"))
            {
                renderer.material = UtilitiesProp;
            }
        }
    }
}