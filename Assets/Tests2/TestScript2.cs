using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SojaExiles;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private GameObject player;
    
    [Test]
    public void testCurrencyGet()
    {
        Currency currency = new Currency(200);
        Assert.AreEqual(currency.GetCoins(),200);
    }

    [Test]
    public void testCurrencySubtract()
    {
        Currency currency = new Currency(200);
        bool result = currency.SubtractGoldCoins(100);
        Assert.AreEqual(result, true);
    }

    [Test]
    public void testCurrencySubtractFail()
    {
        Currency currency = new Currency(200);
        bool result = currency.SubtractGoldCoins(300);
        Assert.AreEqual(result, false);
    }

    [SetUp]
    public void Setup()
    {
        player = new GameObject();
        player.AddComponent<PlayerMovement>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(player);
    }

    [Test]
    public void TestInitialPosition()
    {
        var playerMovement = player.GetComponent<PlayerMovement>();
        Assert.AreEqual(Vector3.zero, playerMovement.transform.position);
    }


    [UnityTest]
    public IEnumerator TestVirtualEconomy()
    {
        var gameObject = new GameObject();
        var virtualcomponent = gameObject.AddComponent<VirtualEconomy>();

        Assert.AreEqual(virtualcomponent.Buy(100),false);

        yield return null;
    }

 
}
