using UnityEngine;

public class FreeParkiingScript : MonoBehaviour
{

    
    public int freeParkingFines = 0;
    void LandedOnFreeParking(Player player)
    {

        player.money += freeParkingFines;
        freeParkingFines = 0;
        Debug.Log("You landed on Free Parking!");
    }
}