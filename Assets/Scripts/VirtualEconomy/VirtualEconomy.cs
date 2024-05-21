using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;



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
        bool status = Buy(price);

    }

    public void Sell()
    {
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        Currency currencyManager = new Currency(accountbalance);
        currencyManager.AddGoldCoins(price);
        if (removeSoldInventory())
        {
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
            return true; //Purchase successful
        }
        else
        {
            return false; //Insufficient Funds
        }

    }

    
       


}
