using UnityEngine;
using System.Collections.Generic;


public class Banker
{
    private int numOfPlayers = 1; //temp
    public List<Player> players; // idk where to get the players array from

    const int GO_MONEY = 200;
    const int STARTING_MONEY = 1500;

    private bool passedGo = false;
    private int index = 0;

    private Dictionary<int, PropertyData> propertyData;
    private Dictionary<string, List<int>> colourPositions;

    private void Start() {
        // load the property data dictionary
        propertyData = CSVLoader.LoadPropertyData();
        if (propertyData == null || propertyData.Count == 0)
        {
            Debug.LogError("propertyData is null or empty.");
            return;
        }

        // create a dictionary where the key is the property colour groups and the values are integer lists for property positions
        colourPositions = new Dictionary<string, List<int>> {
            {"Brown", new List<int>()},
            {"Blue", new List<int>()},
            {"Purple", new List<int>()},
            {"Orange", new List<int>()},
            {"Red", new List<int>()},
            {"Yellow", new List<int>()},
            {"Green", new List<int>()},
            {"Deep blue", new List<int>()}
        };

        // loop through the board to add the property positions to their respective colour groups in the dictionary
        foreach(var property in propertyData) {
            if (colourPositions.ContainsKey(property.Value.Group)) {
                colourPositions[property.Value.Group].Add(property.Value.Position);
            }
        }

        // 3. bank has 50,000 money at start and assigns all players 1,500 at start of game
        for (int i = 1; i <= numOfPlayers; i++) {
            players[i].money = STARTING_MONEY;
        }

        InputDisplay.Instance.UpdateScoreboard(); // update the scoreboard with the starting money for each player
    }

    public void collectGoMoney(Player player) {
        // 9. when a player pasts Go they collect 200 money from the bank
        player.money += GO_MONEY;
        InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
    }

        // - 10. all properties are originally the bank's - to do in property script
    public async void purchaseProperty(Player currentPlayer) {
        // 9. players may not purchase properties until they've made on circuit of the board (pass go once)
        PropertyData property = propertyData[currentPlayer.position];
        if (currentPlayer.passedGo && property.CanBeBought){ 
            // 11. once a player has moved if they land on an a property that isn't yet purchased they have the opportunity to buy it
            bool wantsToBuy = await InputDisplay.Instance.AskYesOrNo("Do you want to purchase this property?");
            if (wantsToBuy) {
                // 10. when property is bought the property is transferred from the bank to player and the money paid from player to bank
                property.OwnerIndex = currentPlayer.playerIndex;
                currentPlayer.money -= property.Cost;
                property.CanBeBought = false;

                InputDisplay.Instance.UpdateScoreboard(); // update scoreboard 
            }
            else if (!wantsToBuy) {
                // 11. if the player doesn't buy a property then it's auctioned by the bank
                auctionProperty(currentPlayer, property);
            }
        }
    }

    public async void auctionProperty(Player refusedPlayer, PropertyData property) {
        int highestBid = 0;
        // 11. if there are no bids then the property remains unsold
        int highestBidderIndex = 0; // players[0] is an inactive player that acts as the bank

        List<Player> bidders = players; //imagining a player array
        bidders[(refusedPlayer.index)] = null;
        int numOfBidders = numOfPlayers - 1;
        int currentNumOfBidders = numOfBidders;
        int bid = 0;

        while (numOfBidders > 1) {
            numOfBidders = currentNumOfBidders;
            for (int i = 0; i < numOfBidders; i++) {
                // 11. all bidding players must've completed one circuit of the board
                if (bidders[i] != null && bidders[i].passedGo) { 
                    bool wantsToBid = await InputDisplay.Instance.AskYesOrNo("Would you like to bid on this property?");
                    if (wantsToBid) {
                        bool validBid = false;
                        while (!validBid) {
                            string bidInput = await InputDisplay.Instance.AskInput("Enter the amount you want to bid");
                            if (int.TryParse(bidInput, out bid)) {
                                validBid = true;
                            }
                        }
                        // 11. in auction each player makes a bid to the bank and the bank sells to the highest bidder
                        if (bid > highestBid) {
                            highestBid = bid;
                            highestBidderIndex = i;
                        }
                    }
                    else {
                        currentNumOfBidders--;
                        bidders[i] = null;
                        if (currentNumOfBidders == 1) { // if there's only one other bidder then the for loop should break
                            break;
                        }
                    }
                }
            }
        }
        property.OwnerIndex = highestBidderIndex;
        InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
    }

    public void payRent(Player currentPlayer) {
        // 12. if a player lands on a property owned by another they must pay the player who owns the property the value of the rent
        int rent = 0;
        bool owned = true;
        PropertyData property = propertyData[currentPlayer.position];

        if (property.OwnerIndex != currentPlayer.playerIndex && property.OwnerIndex != 0 && property.RentCollect) { // all unsold properties are owned by the bank, so if the property landed on is owned by another player then pay rent 
            if (colourPositions.TryGetValue(property.Group, out List<int> positions)) { // get the list of property positions for the current property's colour group
                foreach (int pos in positions) {
                    if (propertyData[pos].OwnerIndex != property.OwnerIndex) {
                        owned = false;
                        break;
                    }
                }
            }

            // 14. if a property is improved with houses or hotels then the rent to be paid is as shown on the card
            if (property.NumOfHouses > 0) {
                rent = property.Houses[(property.NumOfHouses - 1)];
            }
            // 13. if a player owns all of the properties in a colour coded group but the properties are otherwise not developed further
            // - with houses and hotels then the rent is doubled
            else if (owned) {
                rent = property.Rent * 2;
            }
            else {
                rent = property.Rent;
            }

            if (currentPlayer.money < rent) {
                unableToPay(rent, currentPlayer);
            }
            currentPlayer.money -= rent;
            players[property.OwnerIndex].money += rent;

            InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
        }
    }

    // - 15. if they are still unable to pay after selling all assests then they are bankrupt and must leave the game
    // - their game token is removed from the board
    public async void unableToPay(int rentToPay, Player currentPlayer) {
        PropertyData property = null;
        // 15. all rents must be paid in money, if a player is unable to pay the rent then they must sell game assets to make good on the rent
        while (rentToPay > currentPlayer.money){
            bool found = false;
            while (!found) {
                string propertyConsidered = await InputDisplay.Instance.AskInput("You are unable to pay the rent, which property would you like to sell or mortgage?");
                for(int i = 0; i < currentPlayer.owned.Count(); i++) {
                    // maybe the Player object needs an array of the positions of the properties they own
                    if (currentPlayer.owned[i].NameProperty == propertyConsidered) {
                        property = currentPlayer.owned[i];
                        found = true;
                    }
                    else {
                        await InputDisplay.Instance.ShowMessage("You do not own this property, please try again.");
                    }
                }
            }

            bool mortgage = await InputDisplay.Instance.AskMortgageOrSell("Would you like to mortgage or sell this property?");
            if (mortgage) {
                mortgageProperty(currentPlayer, property);
            }
            else {
                sellProperty(currentPlayer, property);
            }

            if (currentPlayer.money < rentToPay && currentPlayer.owned.Count == 0) {
                    await InputDisplay.Instance.ShowMessage("You are bankrupt, please leave the game.");
                    // remove player from game
                    players[currentPlayer.index] = null;
                    InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
                }
            else if (currentPlayer.money < rentToPay && currentPlayer.owned.Count > 0) {
                await InputDisplay.Instance.ShowMessage("You are still unable to pay the rent, please sell or mortgage another property.");
            }
        }
    }

    public void mortgageProperty(Player currentPlayer, PropertyData property) {
        // 23. if a player needs to raise funds, they may mortgage a property with the bank. the bank will pay the player one half of the value
        // - of the property. no rents may be collected for that property whilst it is under mortgage
        currentPlayer.money += (property.Cost/2);
        property.RentCollect = false;
        property.Mortgaged = true;
        InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
    }
    
    public void unMortgageProperty(Player currentPlayer, PropertyData property) {
        currentPlayer.money -= (property.Cost/2);
        property.RentCollect = true;
        property.Mortgaged = false;
        InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
    }

    
    public async void sellProperty(Player currentPlayer, PropertyData property) {
        // 20. a property can only be sold when there are no houses or hotels on the property. 
        // - a player may also sell houses and hotels back to the bank for the original price
        if (property.NumOfHouses > 0) {
            bool validInput = false;
            int housesToSell = 0;
            while (!validInput) {
                string playerInput = await InputDisplay.Instance.AskInput("How many houses would you like to sell?");
                if (int.TryParse(playerInput, out housesToSell)) {
                    validInput = true;
                }
                else {
                    await InputDisplay.Instance.ShowMessage("Invalid input, please enter a number.");
                }
            }
            if (housesToSell > property.NumOfHouses) {
                housesToSell = property.NumOfHouses;
            }
            int money = 0;
            for (int i = 0; i < housesToSell; i++) {
                money = money + property.Houses[i];
            }
            currentPlayer.money += money;
            property.NumOfHouses -= housesToSell;
        }
        else {
            int sellPrice = property.Cost;
            // 24. if a mortgaged property is then sold back to the bank it is sold for one half of the property price as shown on the card
            if (property.Mortgaged) {
                sellPrice = sellPrice/2;
                property.Mortgaged = false;
                property.RentCollect = true;
            }
            // 20. if a player needs to raise funds they can sell a property back to the bank for its original value as shown on the game card
            currentPlayer.money += sellPrice;
            currentPlayer.owned.Remove(property);
            property.CanBeBought = true;
            property.OwnerIndex = 0;
        }
        InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
    }


    // - 17. only during turn after movement and after completing any property purchase, the current player has the option to buy houses
    // - and hotels to improve their properties

    public async void improveProperty(Player currentPlayer) {
        bool improve = await InputDisplay.Instance.AskYesOrNo("Would you like to improve a property?");
        if (improve) {
            bool found = false;
            PropertyData property = null;
            while (!found) {
                string propertyConsidered = await InputDisplay.Instance.AskInput("Which property would you like to improve?");
                for(int i = 0; i < currentPlayer.owned.Count; i++) {
                    if (currentPlayer.owned[i].NameProperty == propertyConsidered) {
                        property = currentPlayer.owned[i];
                        found = true;
                    }
                    else {
                        await InputDisplay.Instance.ShowMessage("You do not own this property, please try again.");
                    }
                }
            }

            // 22. the maximum development permitted on any one property is one hotel
            if (property.NumOfHouses >= 5) { //I want to add another variable for the number of houses 
                await InputDisplay.Instance.ShowMessage("You cannot improve this property any further.");
                return;
            }


            if (colourPositions.TryGetValue(property.Group, out List<int> positions)) {
                bool owned = true;
                for (int i = 0; i < positions.Count; i++) {
                    // 18. houses and hotels may only be purchased where a player owns all of the properties in a colour group
                    if (propertyData[positions[i]].OwnerIndex != currentPlayer.playerIndex) {
                        owned = false;
                        await InputDisplay.Instance.ShowMessage("You do not own all of the properties in this colour group, you cannot improve this property.");
                        return;
                    }
                    // 21. where a colour group of properties is owned by a player there can never be a difference of more than 1 house between the
                    // - properties in that set if a player wishes to buy a hotel, that is the equivalent of 5 houses cost. a player may have 4 houses 
                    // - on one set and a hotel on another in that set
                    if (propertyData[positions[i]].NumOfHouses < property.NumOfHouses) {
                        await InputDisplay.Instance.ShowMessage("You cannot improve this property to a difference of more than 1 house between each property in a set.");
                        return;
                    }
                }
            }

            // 19. houses and hotels are purchased for the amount shown on the game card
            int price = property.Houses[property.NumOfHouses];
            currentPlayer.money -= price;
            property.NumOfHouses ++;

            InputDisplay.Instance.UpdateScoreboard(); // update scoreboard
        }
    }
}