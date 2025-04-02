using UnityEngine;

public class Banker
{
    private int bankCash;
    public GameObject player;
    private int numOfPlayers = 1; //temp, don't know how players are working

    ///
    private int position;
    private Dictionary<int, PropertyData> propertyData;

    private void Start() {
        ///
        if (int.TryParse(gameObject.name, out position))
        {
            propertyData = CSVLoader.LoadPropertyData();
        }

        // 3. bank has 50,000 cash at start
        bankCash = 50000;
        // 3. assign all players 1,500 at start of game
        for (int i = 1; i <= numOfPlayers; i++) {
            player.cash = 1500; //does this money have to come from the bank?
            //bankCash -= 1500;?
        }
    }

    public void collectGoCash() {
        // 9. when a player pasts Go they collect 200 cash from the bank
        player.cash += 200;
        bankCash -= 200;
    }

    // 10. all properties are originally the bank's
    public void purchaseProperty(currentPlayer) {
        // 9. players may not purchase properties until they've made on circuit of the board (pass go once)
        PropertyData property = propertyData[currentPlayer.position];
        if (currentPlayer.circuitComplete && property.CanBeBought){ //"uhh dunno what to do here with game objects and varirables"
            // 11. once a player has moved if they land on an a property that isn't yet purchased they have the opportunity to buy it
            Console.WriteLine("Do you want to purchase this property? Y/N ");
            if (Input.GetKeyDown(KeyCode.y)){
                // 10. when property is bought the property is transferred from the bank to player and the money paid from player to bank
                property.owner = currentPlayer;
                currentPlayer.cash -= property.Price;
                bankCash += property.Price;
                property.CanBeBought = false; 
            }
            else if (Input.GetKeyDown(KeyCode.n)){
                // 11. if the player doesn't buy a property then it's auctioned by the bank
                auctionProperty(currentPlayer, property);
            }
        }
    }


    public void auctionProperty(refusedPlayer, property) {
        // 11. if there are no bids then the property remains unsold
        highestBid = 0;
        highestBidderNum = 0; //0 = banker?
        for (int i = 1; i <= numOfPlayers; i++) {
            currentPlayer // = the player number, idk arrays or whatever, shall figure it out
            // 11. all bidding players must've completed one circuit of the board
            if (currentPlayer.circuitComplete && refusedPlayer.num != currentPlayer.num) {
                Console.WriteLine("Do you want to bid on this property? Y/N ");
                if (Input.GetKeyDown(KeyCode.y)){
                    Console.WriteLine("Enter amount you want to bid: ");
                    int bid = Console.ReadLine();
                }
                // 11. in auction each player makes a bid to the bank and the bank sells to the highest bidder
                if (bid > highestBid) {
                    highestBid = bid;
                    highestBidderNum = i;
                }
            }
        }
        property.owner = 0;// player num i'll figure it out

    }

    public void mortgageProperty(currentPlayer, property) {
        // 23. if a player needs to raise funds, they may mortgage a property with the bank. the bank will pay the player one half of the value
        // - of the property. no rents may be collected for that property whilst it is under mortgage
        currentPlayer.cash += (property.Price/2);
        bankCash -= (property.Price/2);
        property.rentCollect = false;
        property.mortgaged = true;
    }

    
    // 15. if they are still unable to pay after selling all assests then they are bankrupt and must leave the game
    // - their game token is removed from the board

    // 20. a property can only be sold when there are no houses or hotels on the property. 
    // - a player may also sell houses and hotels back to the bank for the original price
    
    public void sellProperty(rentToPay, currentPlayer) {
        // 15. all rents must be paid in cash, if a player is unable to pay the rent then they must sell game assets to make good on the rent
        while (rentToPay > currentPlayer.cash){
            Console.WriteLine("Which property would you like to sell ");
            propertyToSell = Console.ReadLine();
            // need to find which property
            // need to deal with houses and hotels
            // need to deal with if they have no properties left to sell
            // maybe the Player object needs an array of the positions (keys) of the properties they own
            PropertyData propertyToSell = propertyData[currentPlayer.position]; //temp
            sellPrice = property.Price;
            // 24. if a mortgaged property is then sold back to the bank it is sold for one half of the property price as shown on the card
            if (property.mortgaged) {
                sellPrice = sellPrice/2;
            }
            // 20. if a player needs to raise funds they can sell a property back to the bank for its original value as shown on the game card
            currentPlayer.cash += sellPrice;
            bankCash -= sellPrice;
        }
    }

    // 13. if a player owns all of the properties in a colour coded group but the properties are otherwise not developed further
    // - with houses and hotels then the rent is doubled

    public void payRent(currentPlayer) {
        // 12. if a player lands on a property owned by another they must pay the player who owns the property the value of the rent
        PropertyData currentProperty = propertyData[currentPlayer.position];
        propertyOwner = currentProperty.owner;
        if (!currentProperty.CanBeBought && (propertyOwner != currentPlayer | propertyOwner.index != 0)) { // idk if that'll work
            // 14. if a property is improved with houses or hotels then the rent to be paid is as shown on the card
            if (currentProperty.numOfHouses != 0) {
                rent = currentProperty.Houses[(numOfHouses - 1)];
            }
            else {
                rent = currentProperty.Rent;
            }
            currentPlayer.cash -= rent;
            propertyOwner.cash += rent;
        }
    }


    // 17. only during turn after movement and after completing any property purchase, the current player has the option to buy houses
    // - and hotels to improve their properties

    public void improveProperty(currentPlayer) {
        // idk if you get to pick which properties you wanna improve or if it's just the one you're on rn, so for now I'm assuming the latter
        PropertyData currentProperty = propertyData[currentPlayer.position];

        // 22. the maximum development permitted on any one property is one hotel
        if (currentProperty.numOfHouses >= 5) { //I want to add another variable for the number of houses 
            return;
        }

        groupOwned = true;
        // can we make arrays of the positions of each property in the groups or is that not good
        group = currentProperty.GroupArray; // think we do need arrays otherwise we'll have to check the entire board
        for (int i = 0; i < len(group); i++) {
            if (group[i].owner != currentPlayer) {
                groupOwned = false;
            }
        }
        // 18. houses and hotels may only be purchased where a player owns all of the properties in a colour group

        if (groupOwned) {
            Console.WriteLine("Would you like to improve this property? Y/N");
            Console.ReadLine();
            // I'm assuming since you can't have more than 1 house different between properties in the same group you can only buy one house at time?
                // 21. where a colour group of properties is owned by a player there can never be a difference of more than 1 house between the
                // - properties in that set if a player wishes to buy a hotel, that is the equivalent of 5 houses cost. a player may have 4 houses 
                // - on one set and a hotel on another in that set
            if (Input.GetKeyDown(KeyCode.y)) {
                // is the houses array for the prices of the houses? I'm going to act like it is, and that the price of 1 house is at index 0
                price = currentProperty.houses[currentProperty.numOfHouses];
                // 19. houses and hotels are purchased for the amount shown on the game card
                currentPlayer.cash -= price;
                bankCash += price;
                currentProperty.numOfHouses ++;
            }
        }
    }
}