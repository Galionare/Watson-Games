using UnityEngine;

public class FreeParkiingScript : MonoBehaviour
{

    
    public int freeParkingFines = 0;
    public void LandedOnFreeParking(Player player)
    {
        // Assuming you have a reference to the player object and its money property
        // Add the fines to the player's money when they land on Free Parking
        // You can also add any other logic you want here, like displaying a message or updating UI

        // Example: player.money += freeParkingFines; // Assuming player has a money property
        // Reset the fines after collecting them
    

        player.money += freeParkingFines;
        freeParkingFines = 0;
        Debug.Log("You landed on Free Parking!");
    
}
}
    