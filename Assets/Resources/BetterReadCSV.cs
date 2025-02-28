using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class BetterReadCSV : MonoBehaviour
{

    public TextAsset TextAssetData;
    public TMP_InputField TextInput;
    private string Text;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Rent;
    public TextMeshProUGUI RentFull;
    public TextMeshProUGUI Rent1H;
    public TextMeshProUGUI Rent2H;
    public TextMeshProUGUI Rent3H;
    public TextMeshProUGUI Rent4H;
    public TextMeshProUGUI RentHotel;

    private string Colour;
    public Image EmptyCard;
    public Sprite BrownProp;
    public Sprite BlueProp;
    public Sprite RedProp;
    public Sprite PurpleProp;
    public Sprite OrangeProp;
    public Sprite YellowProp;
    public Sprite GreenProp;
    public Sprite DeepBlueProp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text = TextInput.text;
    }

    public void Search()
    {
        string[] data = TextAssetData.text.Split(new string[] { ";", "\n" }, System.StringSplitOptions.None);
        for (int i = 0; i < data.Length; i++)
        {
            if (Text == data[i])
            {
                Name.text = data[i];
                Rent.text = data[i + 6];
                RentFull.text = data[i + 6];
                Rent1H.text = data[i + 9];
                Rent2H.text = data[i + 10];
                Rent3H.text = data[i + 11];
                Rent4H.text = data[i + 12];
                RentHotel.text = data[i + 13];
                Colour = data[i + 2];
                SpriteChanger();
            }
        }
    }
    public void SpriteChanger()
    {
        if (Colour.Trim().Equals("Brown", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = BrownProp;
        }
        else if (Colour.Trim().Equals("Red", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = RedProp;
        }
        else if (Colour.Trim().Equals("Blue", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = BlueProp;
        }
        else if (Colour.Trim().Equals("Purple", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = PurpleProp;
        }
        else if (Colour.Trim().Equals("Orange", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = OrangeProp;
        }
        else if (Colour.Trim().Equals("Yellow", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = YellowProp;
        }
        else if (Colour.Trim().Equals("Green", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = GreenProp;
        }
        else if (Colour.Trim().Equals("Deep Blue", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = DeepBlueProp;
        }
    }
}
