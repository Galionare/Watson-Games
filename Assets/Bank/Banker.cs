using UnityEngine;
using System.Collections.Generic;


public class Banker
{
    private int numOfPlayers = 1; //temp
                                  // public List<Player> players; // idk where to get the players array from

    const int GO_CASH = 200;
    const int STARTING_CASH = 1500;

    public Testing Properties2;
    public Testing Players2;

    List<GameObject> bidders = new List<GameObject>();

    List<GameObject> PlayerList;
    List<GameObject> StreetPropertyList;
    List<GameObject> StationPropertyList;
    List<GameObject> UtilityPropertyList;

    private bool passedGo = false;
    private int index = 0;

    private Dictionary<int, PropertyData> propertyData;
    private Dictionary<string, List<int>> colourPositions;

    private void Start()
    {
        propertyData = CSVLoader.LoadPropertyData();

        List<List<GameObject>> AllPropertiesList = Properties2.AllProperties;

        StreetPropertyList = Properties2.AllProperties[0];
        StationPropertyList = Properties2.AllProperties[1];
        UtilityPropertyList = Properties2.AllProperties[2];
        PlayerList = Players2.Players;


        if (propertyData == null || propertyData.Count == 0)
        {
            Debug.LogError("propertyData is null or empty.");
            return;
        }

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

        foreach (var property in StreetPropertyList)
        {
            if (colourPositions.ContainsKey(property.GetComponent<StreetCard>().Group))
            {
                colourPositions[property.GetComponent<StreetCard>().Group].Add(property.GetComponent<StreetCard>().Position);
            }
        }

        // 3. bank has 50,000 cash at start and assigns all players 1,500 at start of game
        foreach (var player in PlayerList)
        {
            player.GetComponent<Player>().money = STARTING_CASH;
        }
    }


    public void collectGoCash(GameObject player) {
        // 9. when a player pasts Go they collect 200 cash from the bank
        player.GetComponent<Player>().money += GO_CASH;
    }

        // - 10. all properties are originally the bank's - to do in property script
    public async void purchaseProperty(GameObject currentPlayer, GameObject Property) {
        // 9. players may not purchase properties until they've made on circuit of the board (pass go once)
        PropertyData property = propertyData[currentPlayer.GetComponent<Player>().position];
        if (currentPlayer.GetComponent<Player>().passedGO && (!Property.GetComponent<StreetCard>().Owned || !Property.GetComponent<StationCard>().Owned || !Property.GetComponent<UtilityCard>().Owned))
        { 
            // 11. once a player has moved if they land on an a property that isn't yet purchased they have the opportunity to buy it
            bool wantsToBuy = await InputDisplay.Instance.AskYesOrNo("Do you want to purchase this property?");
            if (wantsToBuy) {
                // 10. when property is bought the property is transferred from the bank to player and the money paid from player to bank
                Property.GetComponent<StreetCard>().Owner = currentPlayer;
                Property.GetComponent<StationCard>().Owner = currentPlayer;
                Property.GetComponent<UtilityCard>().Owner = currentPlayer;
                currentPlayer.GetComponent<Player>().money -= Property.GetComponent<StreetCard>().Cost; // no way to know if its a street station or utility yet. I'll do it later
                currentPlayer.GetComponent<Player>().money -= Property.GetComponent<StationCard>().Cost;
                currentPlayer.GetComponent<Player>().money -= Property.GetComponent<UtilityCard>().Cost;
                Property.GetComponent<StreetCard>().Owned = true;
                Property.GetComponent<StationCard>().Owned = true;
                Property.GetComponent<UtilityCard>().Owned = true;
            }
            else if (!wantsToBuy) {
                // 11. if the player doesn't buy a property then it's auctioned by the bank
                auctionProperty(currentPlayer, Property);
            }
        }
    }

    public async void auctionProperty(GameObject refusedPlayer, GameObject property) {
        int highestBid = 0;
        // 11. if there are no bids then the property remains unsold
        int highestBidder = 0;
        int bid;
        //ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg

        bidders.AddRange(PlayerList); //imagining a player array
        //bidders[(refusedPlayer.index)] = 0; hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh i dont understatn hhhhhhhhhh
        int numOfBidders = numOfPlayers - 1; // possibly chage hhhhhhhhhhhhhhhhhhhhhhhh
        int currentNumOfBidders = numOfBidders;

        while (numOfBidders > 1) {
            numOfBidders = currentNumOfBidders;
            for (int i = 0; i < numOfBidders; i++) {
                // 11. all bidding players must've completed one circuit of the board
                if (bidders[i].GetComponent<Player>().passedGO) { // if the player is out of the auction bidders[i] will be the banker who hasn't passed go
                    bool wantsToBid = await InputDisplay.Instance.AskYesOrNo("Would you like to bid on this property?");
                    if (wantsToBid) {
                        
                        bool validBid = false;
                        while (!validBid) {
                            string bidInput = await InputDisplay.Instance.AskInput("Enter the amount you want to bid");
                            //int bid;
                            if (int.TryParse(bidInput, out bid)) {
                                validBid = true;
                            }// else statment to type anther number jjjjjjjjjjjjjjjjjjjjjjjjjjjjj
                        }
                        // 11. in auction each player makes a bid to the bank and the bank sells to the highest bidder
                        if (bid > highestBid) {
                            highestBid = bid;
                            highestBidder = i;
                        }
                    }
                    else {
                        currentNumOfBidders--;
                        bidders[i] = 0; // whattttt???
                        if (currentNumOfBidders == 1) { // if there's only one other bidder then the for loop should break
                            break;
                        }
                    }
                }
            }
        }
        property.GetComponent<StreetCard>().Owner = bidders[highestBidder];
        property.GetComponent<StationCard>().Owner = bidders[highestBidder];
        property.GetComponent<UtilityCard>().Owner = bidders[highestBidder];
    }

    public void payRent(GameObject currentPlayer, GameObject property) { // cahnge depending on Groupppppppppppppppppppppppppppppppppppppppppppppppppppppppppp
        // 12. if a player lands on a property owned by another they must pay the player who owns the property the value of the rent
        int rent = 0;
        bool owned = true;
        //property = propertyData[currentPlayer.GetComponent<Player>().position];  i think no need hhhhhhhhhhhhhhhhh
        GameObject propertyOwner = property.GetComponent<UtilityCard>().Owner;
        if ((!property.GetComponent<StreetCard>().Owned || !property.GetComponent<StationCard>().Owned || !property.GetComponent<UtilityCard>().Owned) && propertyOwner != currentPlayer && propertyOwner.index != 0) { // idk if that'll work
            if (colourPositions.TryGetValue(property.GetComponent<StreetCard>().Group, out List<int> positions)) { // where does this go??? jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj
                foreach (int i in positions) {
                    if (propertyData[positions[i]].Owner != propertyOwner) { // I dont understandddddddddddddddddddddddddddddddddd
                        owned = false;
                        break;
                    }
                }
            }

            // 14. if a property is improved with houses or hotels then the rent to be paid is as shown on the card
            if (property.GetComponent<StreetCard>().NumOfHouses != 0) {
                rent = property.GetComponent<StreetCard>().Houses[(property.GetComponent<StreetCard>().NumOfHouses - 1)];
            }
            // 13. if a player owns all of the properties in a colour coded group but the properties are otherwise not developed further
            // - with houses and hotels then the rent is doubled
            else if (owned) {
                rent = property.GetComponent<StreetCard>().FullRent1;
            }
            else {
                rent = property.GetComponent<StreetCard>().Rent1;
            }

            if (currentPlayer.GetComponent<Player>().money < rent) {
                unableToPay(rent, currentPlayer);
            }
            currentPlayer.GetComponent<Player>().money -= rent;
            propertyOwner.GetComponent<Player>().money += rent;
        }
    }

    // - 15. if they are still unable to pay after selling all assests then they are bankrupt and must leave the game
    // - their game token is removed from the board
    public async void unableToPay(int rentToPay, GameObject currentPlayer) {
        // 15. all rents must be paid in cash, if a player is unable to pay the rent then they must sell game assets to make good on the rent
        while (rentToPay > currentPlayer.GetComponent<Player>().money)
        {
            bool found = false;
            while (!found) {
                string propertyConsidered = await InputDisplay.Instance.AskInput("You are unable to pay the rent, which property would you like to sell or mortgage?");
                for(int i = 0; i < currentPlayer.owned.Length(); i++) {
                    // maybe the Player object needs an array of the positions of the properties they own
                    if (currentPlayer.owned[i].NameProperty == propertyConsidered) {
                        PropertyData property = currentPlayer.owned[i];
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

            if (currentPlayer.GetComponent<Player>().money < rentToPay && currentPlayer.owned.Count == 0) {
                    await InputDisplay.Instance.ShowMessage("You are bankrupt, please leave the game.");
                    // remove player from game
                }
            else if (currentPlayer.GetComponent<Player>().money < rentToPay && currentPlayer.owned.Count > 0) {
                await InputDisplay.Instance.ShowMessage("You are still unable to pay the rent, please sell or mortgage another property.");
            }
        }
    }

    public void mortgageProperty(GameObject currentPlayer, GameObject property) {
        // 23. if a player needs to raise funds, they may mortgage a property with the bank. the bank will pay the player one half of the value
        // - of the property. no rents may be collected for that property whilst it is under mortgage
        currentPlayer.GetComponent<Player>().money += (property.GetComponent<StreetCard>().Mortgage);
        //property.rentCollect = false; // I f¡think no needdddddddddddddddddddddddddddd
        property.GetComponent<StreetCard>().Mortgaged = true;
    }
    
    public void unMortgageProperty( GameObject currentPlayer, GameObject property) {
        currentPlayer.GetComponent<Player>().money -= (property.GetComponent<StreetCard>().Mortgage);
        //property.rentCollect = true; // I think no needddddddddddddddddddddddddddd
        property.GetComponent<StreetCard>().Mortgaged = false;
    }

    
    public async void sellProperty(GameObject currentPlayer, GameObject property) {
        // 20. a property can only be sold when there are no houses or hotels on the property. 
        // - a player may also sell houses and hotels back to the bank for the original price
        if (property.GetComponent<StreetCard>().NumOfHouses > 0) {
            bool validInput = false;
            int housesToSell;
            while (!validInput) {
                string playerInput = await InputDisplay.Instance.AskInput("How many houses would you like to sell?");
                if (int.TryParse(playerInput, out housesToSell)) {
                    validInput = true;
                }
                else {
                    await InputDisplay.Instance.ShowMessage("Invalid input, please enter a number.");
                }
            }
            if (housesToSell > property.GetComponent<StreetCard>().NumOfHouses) {
                housesToSell = property.GetComponent<StreetCard>().NumOfHouses;
            }
            int cash = 0;
            for (int i = 0; i < housesToSell; i++) {
                cash = cash + property.GetComponent<StreetCard>().Houses[i];
            }
            currentPlayer.GetComponent<Player>().money += cash;
            property.GetComponent<StreetCard>().NumOfHouses -= housesToSell;
        }
        else {
            int sellPrice = property.GetComponent<StreetCard>().Cost;
            // 24. if a mortgaged property is then sold back to the bank it is sold for one half of the property price as shown on the card
            if (property.GetComponent<StreetCard>().Mortgaged) {
                sellPrice = sellPrice/2;
                property.GetComponent<StreetCard>().Mortgaged = false;
                property.rentCollect = true;
            }
            // 20. if a player needs to raise funds they can sell a property back to the bank for its original value as shown on the game card
            currentPlayer.GetComponent<Player>().money += sellPrice;
            currentPlayer.owned.Remove(property);
            property.CanBeBought = true;
            property.Owner = 0;// laterrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr
        }
    }


    // - 17. only during turn after movement and after completing any property purchase, the current player has the option to buy houses
    // - and hotels to improve their properties

    public async void improveProperty(GameObject currentPlayer) {
        bool improve = await InputDisplay.Instance.AskYesOrNo("Would you like to improve a property?");
        if (improve) {
            bool found = false;
            GameObject property = null;
            while (!found) {
                string propertyConsidered = await InputDisplay.Instance.AskInput("Which property would you like to improve?");
                for(int i = 0; i < currentPlayer.owned.Length; i++) {
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
            if (property.GetComponent<StreetCard>().NumOfHouses >= 5) { //I want to add another variable for the number of houses 
                await InputDisplay.Instance.ShowMessage("You cannot improve this property any further.");
                return;
            }


            if (colourPositions.TryGetValue(property.GetComponent<StreetCard>().Group, out List<int> positions)) {
                bool owned = true;
                for (int i = 0; i < positions.Count; i++) {
                    // 18. houses and hotels may only be purchased where a player owns all of the properties in a colour group
                    if (propertyData[positions[i]].Owner != currentPlayer) {
                        owned = false;
                        await InputDisplay.Instance.ShowMessage("You do not own all of the properties in this colour group, you cannot improve this property.");
                        return;
                    }
                    // 21. where a colour group of properties is owned by a player there can never be a difference of more than 1 house between the
                    // - properties in that set if a player wishes to buy a hotel, that is the equivalent of 5 houses cost. a player may have 4 houses 
                    // - on one set and a hotel on another in that set
                    if (propertyData[positions[i]].NumOfHouses < property.GetComponent<StreetCard>().NumOfHouses) {
                        await InputDisplay.Instance.ShowMessage("You cannot improve this property to a difference of more than 1 house between each property in a set.");
                        return;
                    }
                }
            }

            // 19. houses and hotels are purchased for the amount shown on the game card
            int price = property.GetComponent<StreetCard>().Houses[property.GetComponent<StreetCard>().NumOfHouses]];
            currentPlayer.GetComponent<Player>().money -= price;
            property.GetComponent<StreetCard>().NumOfHouses++;
        }
    }
}