using UnityEngine;
using TMPro;

public class ReadCSV : MonoBehaviour
{

    public TextAsset TextAssetData;
    public TMP_InputField TextInput;
    private string Text;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI DoB;

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
        for (int i = 0; i<data.Length; i++)
        {
            if (Text == data[i])
            {
                Name.text = data[i + 1];
                DoB.text = data[i + 2];
            }
        }
    }
}
