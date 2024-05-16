using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using System;
using Microsoft.Data.SqlClient;



public class VirtualEconomy : MonoBehaviour
{

    private int accountbalance = 300;

    public GameObject MainObject;

    public TextMeshProUGUI textMeshProUGUI;

    public TextMeshProUGUI itemName;

    public List<GameObject> inventoryitems;

    void Start()
    {
       
    }

    public void Purchase()
    {
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        Buy(price);

    }

    public void Sell()
    {
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        CurrencyManager currencyManager = new CurrencyManager(accountbalance);
        currencyManager.AddGoldCoins(price);
        if (removeSoldInventory())
        {
            Destroy(MainObject);
            Debug.Log("SOLD");
        }
        else
        {
            Debug.Log("NOT SOLD");
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
                    string destinationPath = destinationFolder + "/" + purchasedObject.name + ".prefab";
                    PrefabUtility.SaveAsPrefabAsset(purchasedObject, destinationPath);

                    // Destroy the temporary copied GameObject from the scene
                    DestroyImmediate(purchasedObject);

                    // Refresh the AssetDatabase to make sure the new asset is visible in the Editor
                    AssetDatabase.Refresh();

                    Debug.Log("GameObject copied and saved as: " + destinationPath);
                }
            }

        }catch (System.Exception ex)
        {
            Debug.Log(ex.Message); 
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



    private void Buy(int price)
    {
        CurrencyManager currencyManager = new CurrencyManager(accountbalance);
        

        if (currencyManager.SubtractGoldCoins(price))
        {
            accessPurchasedInventory();
            Debug.Log("Purchase successful");
        }
        else
        {
            Debug.Log("Insufficient Funds");
        }

    }

    
       


}
