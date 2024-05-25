using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private GameObject player;
    [Test]
    public void TestCurrencyGet()
    {
        Currency currency = new Currency(200);
        
        Assert.AreEqual(200, currency.GetCoins());
    }

    [Test]
    public void TestCurrencySubtract()
    {
        Currency currency = new Currency(200);
        bool result = currency.Subtract(100);
        Assert.AreEqual(true,result);
    }


    [Test]
    public void TestCurrencySubtractValue()
    {
        Currency currency = new Currency(200);
        bool result = currency.Subtract(100);
        Assert.AreEqual(100, currency.GetCoins());
    }

    [Test]
    public void TestCurrencySubtractFail()
    {
        Currency currency = new Currency(200);
        bool result = currency.Subtract(300);
        Assert.AreEqual(false, result);
    }

    [Test]
    public void TestCurrencyAdd()
    {
        Currency currency = new Currency(200);
        currency.Add(100);
        Assert.AreEqual(300, currency.GetCoins());
    }

    [Test]
    public void TestExtract()
    {
        VirtualEconomy virtualEconomy = new VirtualEconomy();
        string testvalue = virtualEconomy.extractAmount("[{test:test:test:test:value}]");
        Assert.AreEqual("value",testvalue);
    }

    [Test]
    public void TestPriceGenerate()
    {
        UserInventoryManagement userInventoryManagement = new UserInventoryManagement();
        string[] testList = { "L 100", "L 200", "L 300", "L 200", "L 500", "L 200", "L 150" };
        Dictionary<string, string>  output = userInventoryManagement.PriceGenerate(testList);
        Assert.AreEqual(output.Count, 7);
    }


}
