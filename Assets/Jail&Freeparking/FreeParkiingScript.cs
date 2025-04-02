using UnityEngine;

public class FreeParkiingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int freeParkingFines = 0;
    void LandedOnFreeParking(Player player)
    {

        player.Money += freeParkingFines;
        freeParkingFines = 0;
        Debug.Log("You landed on Free Parking!");
    }
}
