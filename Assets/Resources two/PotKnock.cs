using UnityEngine;

public class PotKnock : MonoBehaviour
{
    public GameObject PotCard;
    public List<GameObject> PotPile;
    public List<GameObject> KnockPile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 6; i<= 22; i++)
        {
            GameObject Pot = Instantiate(PotCard) as GameObject;
            Pot.GetComponent<PotLuck>().CreateCard(i);
            PotLuck pos = Pot.GetComponent<PotLuck>();
            pos.Position = i;
            PotPile.Add(Pot);
        }
        for (int i = 27; i <= 42; i++)
        {
            GameObject Knock = Instantiate(PotCard) as GameObject;
            Knock.GetComponent<PotLuck>().CreateCard(i);
            PotLuck pos = Knock.GetComponent<PotLuck>();
            pos.Position = i;
            KnockPile.Add(Knock);
        }
    }


}
