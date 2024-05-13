using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;


public class VirtualEconomy : MonoBehaviour
{

    private int accountbalance = 300;

    public TextMeshProUGUI textMeshProUGUI;

    public TextMeshProUGUI itemName;

    public List<GameObject> inventoryitems;


    public void Purchase()
    {
        string pricetext = textMeshProUGUI.text;
        int price = int.Parse(pricetext.Substring(2));
        Buy(price);

    }

    private void accessPurchasedInventory()
    {
        try
        {
            
            string destinationFolder = "Assets/Prefabs/UserInventory";

            Debug.Log(inventoryitems.Count);


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
