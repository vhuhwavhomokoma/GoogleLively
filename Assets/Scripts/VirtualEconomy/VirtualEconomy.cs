using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

using Button = UnityEngine.UI.Button;



public class VirtualEconomy : MonoBehaviour
{

    private int accountbalance = 600;

    public GameObject MainObject;

    public TextMeshProUGUI textMeshProUGUI;

    public TextMeshProUGUI itemName;

    private GameObject[] inventoryitems;

    public Button BuyButton;



    void Start()
    {


        if (InventoryManager.inventoryInstance != null)
        {
            var items = InventoryManager.inventoryInstance.items;
            // Use items as needed
        }


    }

    public void Purchase()
    {
        StartCoroutine(GetRequest("https://libraryweb4.azurewebsites.net/api/Your")); //concurrency
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        bool status = Buy(price);
        if (status)
        {
            UnityEngine.UI.Image buttonImage = BuyButton.GetComponent<UnityEngine.UI.Image>();
            buttonImage.color = Color.green;
        }
       

    }

    public void Sell()
    {
        StartCoroutine(GetRequest("https://libraryweb4.azurewebsites.net/api/Your")); //concurrency
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        Currency currencyManager = new Currency(accountbalance);
        currencyManager.Add(price);
        if (removeSoldInventory())
        {
            StartCoroutine(updateDBentry(currencyManager.GetCoins()));
            Destroy(MainObject);

        }


    }

    private void accessPurchasedInventory()
    {
        try
        {
            inventoryitems = Resources.LoadAll<GameObject>("MarketCatalogue");

            foreach (GameObject item in inventoryitems)
            {
                if (item.name == itemName.text)
                {
                    InventoryManager.inventoryInstance.AddItem(item);

                }
            }

        }
        catch (System.Exception)
        {

        }

    }

    private bool removeSoldInventory()
    {
        var inventoryItems = InventoryManager.inventoryInstance.items;

        foreach (GameObject prefab in inventoryItems)
        {
            if (prefab != null && prefab.name == itemName.text)
            {
                InventoryManager.inventoryInstance.RemoveItem(prefab);
                return true;
            }
        }

        return false;

    }



    public bool Buy(int price)
    {


        Currency currencyManager = new Currency(accountbalance);


        if (currencyManager.Subtract(price))
        {

            accessPurchasedInventory();
            StartCoroutine(updateDBentry(currencyManager.GetCoins()));//concurrency


            return true; //Purchase successful
        }
        else
        {
            return false; //Insufficient Funds
        }

    }


    IEnumerator updateDBentry(int newamount)
    {
        string url = "https://libraryweb4.azurewebsites.net/api/Your/1";


        string jsonData = "{\"personID\": 1,\"firstName\": \"Vhuhwavho\",\"lastName\": \"Mokoma\",\"amount\": " + newamount + "}"; ;


        UnityWebRequest request = UnityWebRequest.Put(url, jsonData);

        request.SetRequestHeader("Content-Type", "application/json");


        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }



    }


    public string extractAmount(string jsonstring)
    {
        char[] charsToTrim = { '[', ']', '{', '}' };
        string result = jsonstring.Trim(charsToTrim);
        string[] strings = result.Split(":");

        return strings[4];
    }

    //Retrieve the value of the account balance from the databse
    public IEnumerator GetRequest(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        //Check for errors in connection
        if (webRequest.result != UnityWebRequest.Result.ConnectionError)
        {
            string recv = webRequest.downloadHandler.text;

            accountbalance = int.Parse(extractAmount(recv));


        }
    }




}
