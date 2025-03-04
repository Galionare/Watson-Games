using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StationReadCSV : MonoBehaviour
{
    public TextAsset TextAssetData;
    public TMP_InputField TextInput;
    private string Text;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Info1;
    public TextMeshProUGUI Info2;
    public TextMeshProUGUI Info3;
    public TextMeshProUGUI Info4;
    private string Station;
    private string Check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {

        Text = TextInput.text;
        Text.ToLower();
    }

    public void Search()
    {
        string[] data = TextAssetData.text.Split(new string[] { ";", "\n" }, System.StringSplitOptions.None);
        for (int i = 0; i < data.Length; i++)
        {
            if (Text == data[i].ToLower())
            {
                Name.text = data[i];
              /*  Station = data[i + 2];
                if (Station.Trim().Equals("Station", System.StringComparison.OrdinalIgnoreCase))
                {
                    //Name.text = data[i];
                    Check = data[i + 6];

                    if (Check == data[i].ToLower())
                    {
                        Info1.text = data[i + 48];
                        Info2.text = data[i + 64];
                        Info3.text = data[i + 3];
                        Info4.text = data[i + 3];
                    }
                }
              */
            } 
        }
    }
}
