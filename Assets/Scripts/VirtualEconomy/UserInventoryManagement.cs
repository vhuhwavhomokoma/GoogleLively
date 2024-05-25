using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UserInventoryManagement : MonoBehaviour
{
    public GameObject userinventoryEntry;
    public Transform entryParent;



    public float itemSpacing = 200f;

    void Start()
    {
        PopulateScrollView();
    }

    void PopulateScrollView()
    {
        string[] PriceList = { "L 100", "L 200", "L 300", "L 200", "L 500", "L 200", "L 150" };

        var inventoryItems = InventoryManager.inventoryInstance.items;
        Texture[] previewItems = Resources.LoadAll<Texture>("AssetPreviews");



        for (int i = 0; i < inventoryItems.Count; i++)
        {
            // Calculate the position for the new item based on index
            float yOffset = i * 2 * itemSpacing;

            Texture previewTexture = previewItems[i];

            for (int n = 0; n < previewItems.Length; n++)
            {
                if (previewItems[n].name == inventoryItems[i].name)
                {
                    Debug.Log(inventoryItems[i].name);
                    previewTexture = previewItems[n];
                }
            }





            GameObject newItem = Instantiate(userinventoryEntry, entryParent);
            TextMeshProUGUI[] allTextMeshProChildren = newItem.GetComponentsInChildren<TextMeshProUGUI>();



            allTextMeshProChildren[0].text = inventoryItems[i].name;
            allTextMeshProChildren[0].color = Color.black;
            allTextMeshProChildren[0].fontSize = 12;


            allTextMeshProChildren[2].text = PriceList[i];
            allTextMeshProChildren[2].color = Color.white;
            allTextMeshProChildren[2].fontSize = 18;


            RawImage image = newItem.GetComponentInChildren<RawImage>();
            image.texture = previewTexture;

            // Set the position of the new item
            RectTransform itemRect = newItem.GetComponent<RectTransform>();
            if (itemRect != null)
            {
                itemRect.anchoredPosition = new Vector2(-300, yOffset);
            }

        }

    }
}
