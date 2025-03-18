[System.Serializable]
public class BoardSpace
{
    public int position;
    public string name;
    public string group;
    public string action;
    public bool canBeBought;
    public int cost;
    public int rent;
    public int[] houseRents; // Array for rent values when improved
}