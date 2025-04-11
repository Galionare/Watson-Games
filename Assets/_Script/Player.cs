using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex;
    public int money = 1500;
    public int position;
    public int jailTurn;
    public List<string> cards;
    public List<PropertyData> owned;
    public bool isRolled = false;
    public bool passedGo = false;
    public int index;
}
