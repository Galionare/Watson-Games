using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UIElements;
using System;

public class ReadExcel : MonoBehaviour
{
    public TextAsset textAssetData;


        public int position;
        public new string name;
        public string group;
        public string action;
        public string canBeBought;

    public TMP_InputField textInput;
    public TextMeshProUGUI Profession;
    public TextMeshProUGUI Class;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (int.TryParse(gameObject.name, out position))
        {
            Debug.Log("GameObject ID: " + position);
            Search();

        }
    }

        // Update is called once per frame
        public void Search()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

        for (int i = 0; i < data.Length; i++) {
            if (int.TryParse(data[i], out int dataPosition))
                {
                Debug.Log("Match Found: " + data[i]);
                name = data[i + 1];
                Debug.Log("Match Found: " + data[i+1]);
                group = data[i + 3];
                //Debug.Log("Match Found: " + data[i + 3]);
                //action = data[i + 3];
               // canBeBought = data[i + 4];
            }
        }

    }
}
