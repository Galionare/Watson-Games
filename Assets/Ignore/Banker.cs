using UnityEngine;

public class Banker
{
    private int totalCash;
    public GameObject player;
    private int numOfPlayers = 1; //"temp, don't know how players are working"

    private void Start() {
        // bank has 50,000 cash at start
        totalCash = 50000;
        // assign all players 1,500 at start of game
        for (int i = 1; i <= numOfPlayers; i++) {
            player.cash = 1500; //"does this money have to come from the bank?"
            //"totalCash -= 1500;?"
        }
    }

    public void collectGoCash() {
        // when a player pasts Go they collect 200 cash from the bank
        player.cash += 200;
        totalCash -= 200;
    }

    // all properties are originally the bank's
    public void purchaseProperty() {
        // players may not purchase properties until they've made on circuit of the board (pass go once)
        if (player.circuitComplete && property.CanBeBought){ //"uhh dunno what to do here with game objects and varirables"
            // once a player has moved if they land on an a property that isn't yet purchased they have the opportunity to buy it
            Console.WriteLine("Do you want to purchase this property? Y/N ");
            if (Input.GetKeyDown(KeyCode.y)){
                // when property is bought the property is transferred from the bank to player and the money paid from player to bank
                property.owner = player;
                player.cash -= property.Price;
                totalCash += property.Price;
                property.CanBeBought = false; 
            }
            else if (Input.GetKeyDown(KeyCode.n)){
                // if the player doesn't buy a property then it's auctioned by the bank
                auctionProperty(player);
            }
        }
    }


    public void auctionProperty(refusedPlayer) {
        // if there are no bids then the property remains unsold
        highestBid = 0;
        highestBidderNum = 0; //0 = banker?
        for (int i = 1; i <= numOfPlayers; i++) {
            currentPlayer // = the player number, idk arrays or whatever, shall figure it out
            // all bidding players must've completed one circuit of the board
            if (currentPlayer.circuitComplete && refusedPlayer.num != player.num) {
                Console.WriteLine("Do you want to bid on this property? Y/N ");
                if (Input.GetKeyDown(KeyCode.y)){
                    Console.WriteLine("Enter amount you want to bid: ");
                    int bid = Console.ReadLine();
                }
                // in auction each player makes a bid to the bank and the bank sells to the highest bidder
                if (bid > highestBid) {
                    highestBid = bid;
                    highestBidderNum = i;
                }
            }
        }
        property.owner = 0;// player num figure it out im tired

    }

    public void mortgageProperty() {
        // if a player needs to raise funds, they may mortgage a property with the bank. the bank will pay the player one half of the value
        // - of the property. no rents may be collected for that property whilst it is under mortgage
        // if a mortgaged property is then sold back to the bank it is sold for one half of the property price as shown on the card
        player.cash += (property.Price/2);
        totalCash -= (property.Price/2);
        property.rentCollect = false;
        property.mortgaged = true;
    }

    // all rents must be paid in cash, if a player is unable to pay the rent then they must sell game assets to make good on the rent
    // if they are still unable to pay after selling all assests then they are bankrupt and must leave the game
    // - their game token is removed from the board
    // if a player needs to raise funds they can sell a property back to the bank for its original value as shown on the game card
    // a property can only be sold when there are no houses or hotels on the property
    // a player may also sell houses and hotels back to the bank for the original price
    
    public void sellProperty(rentToPay, currentPlayer) {
        while (rentToPay > currentPlayer.cash){
            Console.WriteLine("Which property would you like to sell ");
            propertyToSell = Console.ReadLine();
            // need to find which property
            // need to deal with houses and hotels
        }
    }
}
