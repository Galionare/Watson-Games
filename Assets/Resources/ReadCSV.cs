using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadCSV : MonoBehaviour
{

    public TextAsset TextAssetData;
    public TMP_InputField TextInput;
    private string Text;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI DoB;
    public TextMeshProUGUI Colour;
    public Image EmptyCard;
    public Sprite BrownProp;
    public Sprite BlueProp;
    public Sprite RedProp;



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
        string[] data = TextAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        for (int i = 3; i<data.Length; i++)
        {
            if (Text == data[i])
            {
                Name.text = data[i + 1];
                DoB.text = data[i + 2];
                Colour.text = data[i + 3];
                SpriteChanger();
            }
        }
    }
    public void SpriteChanger() 
    {
        if (Colour.text.Trim().Equals("Brown", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = BrownProp;
        }
        else if (Colour.text.Trim().Equals("Red", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = RedProp;
        }
        else if (Colour.text.Trim().Equals("Blue", System.StringComparison.OrdinalIgnoreCase))
        {
            EmptyCard.sprite = BlueProp;
        }
    }
}
