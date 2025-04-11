using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPropery : MonoBehaviour
{
    public Player player
    public int Position;

    public void ShowProp()
    {
        position = player.position;
        CreateCard(Position)
    }

}
