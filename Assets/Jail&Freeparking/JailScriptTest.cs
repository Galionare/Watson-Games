using NUnit.Framework;
using System.Collections.Generic;

public class JailScriptTest
{
    private JailScript jailScript;
    private Player player;
    private FreeParkiingScript parkingScript;

    [SetUp]
    public void Setup()
    {
        jailScript = new JailScript();
        player = new Player
        {
            position = 0,
            money = 100,
            turnsToWait = 0,
            cards = new List<string>()
        };
        parkingScript = new FreeParkiingScript();
        jailScript.ParkingScript = parkingScript;
    }

    [Test]
    public void GoToJail_PlayerUsesGetOutOfJailFreeCard()
    {
        player.cards.Add("Get out of Jail Free");

        jailScript.GoToJail(player);

        Assert.AreEqual(10, player.position); // Player is released
        Assert.IsFalse(player.cards.Contains("Get out of Jail Free")); // Card is removed
        Assert.AreEqual(0, player.turnsToWait); // No turns to wait
    }

    [Test]
    public void GoToJail_PlayerPays50ToGetOut()
    {
        player.money = 100;
        bool playerWantToPay = true;

        jailScript.GoToJail(player);

        Assert.AreEqual(10, player.position); // Player is released
        Assert.AreEqual(50, player.money); // Player paid 50
        Assert.AreEqual(50, parkingScript.freeParkingFines); // Money added to free parking pool
        Assert.AreEqual(0, player.turnsToWait); // No turns to wait
    }

    [Test]
    public void GoToJail_PlayerCannotPayAndHasNoCard()
    {
        player.money = 30;

        jailScript.GoToJail(player);

        Assert.AreEqual(11, player.position); // Player remains in jail
        Assert.AreEqual(3, player.turnsToWait); // Player must wait 3 turns
    }

    [Test]
    public void GoToJail_PlayerHasNoCardAndDeclinesToPay()
    {
        player.money = 100;
        bool playerWantToPay = false;

        jailScript.GoToJail(player);

        Assert.AreEqual(11, player.position); // Player remains in jail
        Assert.AreEqual(3, player.turnsToWait); // Player must wait 3 turns
        Assert.AreEqual(100, player.money); // Player did not pay
    }
}

public class Player
{
    public int position;
    public int money;
    public int turnsToWait;
    public List<string> cards;
}

public class FreeParkiingScript
{
    public int freeParkingFines;
}