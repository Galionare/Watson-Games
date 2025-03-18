using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoardManager : MonoBehaviour
{
    public List<BoardSpace> boardSpaces = new List<BoardSpace>();

    void Start()
    {
        LoadBoardData();
    }

    void LoadBoardData()
    {
        TextAsset boardData = Resources.Load<TextAsset>("PropertyTycoonBoardData");
        if (boardData == null)
        {
            Debug.LogError("CSV file not found in Resources folder.");
            return;
        }

        string[] lines = boardData.text.Split('\n');
        for (int i = 1; i < lines.Length; i++) // Skip header row
        {
            string[] values = lines[i].Split(',');

            if (values.Length < 7) continue; // Ensure row has enough data

            BoardSpace space = new BoardSpace
            {
                position = int.Parse(values[0]),
                name = values[1],
                group = values[2],
                action = values[3],
                canBeBought = values[4].Trim().ToLower() == "yes",
                cost = values[5] == "" ? 0 : int.Parse(values[5]),
                rent = values[6] == "" ? 0 : int.Parse(values[6]),
                houseRents = new int[]
                {
                    values[7] == "" ? 0 : int.Parse(values[7]),
                    values[8] == "" ? 0 : int.Parse(values[8]),
                    values[9] == "" ? 0 : int.Parse(values[9]),
                    values[10] == "" ? 0 : int.Parse(values[10]),
                    values[11] == "" ? 0 : int.Parse(values[11])
                }
            };

            boardSpaces.Add(space);
        }

        Debug.Log("Board data loaded! Total spaces: " + boardSpaces.Count);
    }
}