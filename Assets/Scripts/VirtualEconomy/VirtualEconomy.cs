using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;



public class VirtualEconomy : MonoBehaviour
{

    private int accountbalance;

    public GameObject MainObject;

    public TextMeshProUGUI textMeshProUGUI;

    public TextMeshProUGUI itemName;

    public List<GameObject> inventoryitems;

   

    void Start()
    {
        


    }

    public void Purchase()
    {
        StartCoroutine(GetRequest("https://libraryweb4.azurewebsites.net/api/Your")); //concurrency
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        bool status = Buy(price);

    }

    public void Sell()
    {
        StartCoroutine(GetRequest("https://libraryweb4.azurewebsites.net/api/Your")); //concurrency
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        Currency currencyManager = new Currency(accountbalance);
        currencyManager.AddGoldCoins(price);
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
            
            string destinationFolder = "Assets/Prefabs/UserInventory";


            foreach (GameObject item in inventoryitems)
            {
                if (item.name == itemName.text)
                {
                    GameObject purchasedObject = Instantiate(item);
                    string destinationPath = destinationFolder + "/" + itemName.text + ".prefab";
                    PrefabUtility.SaveAsPrefabAsset(purchasedObject, destinationPath);

               
                    DestroyImmediate(purchasedObject);

                    
                    AssetDatabase.Refresh();

                }
            }

        }catch (System.Exception)
        {
         
        }

}

    private bool removeSoldInventory()
    {
        string prefabsFolder = "Assets/Prefabs/UserInventory";
      
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new[] { prefabsFolder });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
            if (prefab != null && prefab.name == itemName.text)
            {
                AssetDatabase.DeleteAsset(assetPath);
                return true;
            }
        }

        return false;

    }



    public bool Buy(int price)
    {
       
        
        Currency currencyManager = new Currency(accountbalance);
        

        if (currencyManager.SubtractGoldCoins(price))
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
            else
            {
                Debug.Log("PUT request successful");
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
