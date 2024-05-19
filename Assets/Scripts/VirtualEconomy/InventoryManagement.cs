using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class InventoryManagement : MonoBehaviour
{


    public GameObject contentPrefab; // Reference to the prefab of your content item
    public Transform contentParent; // Reference to the Content transform of the Scroll View

    public List<GameObject> items; // List of items to display in the Scroll View

    public float itemSpacing = 200f; // Spacing between each item in the ScrollView

    
    void Start()
    {
        PopulateScrollView();
        
       
    }
   


    void PopulateScrollView()
    {
        string[] PriceList = {"L 100","L 200","L 300" };
        

        // Loop through each item in the list
        for (int i = 0; i < items.Count; i++)
        {
            // Calculate the position for the new item based on index
            float yOffset = i *2* itemSpacing; // Adjust this calculation based on your layout needs

            Texture previewTexture = AssetPreview.GetAssetPreview(items[i]);


            // Instantiate a new content item from the prefab
            GameObject newItem = Instantiate(contentPrefab, contentParent);
            TextMeshProUGUI[] allTextMeshProChildren = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            


            allTextMeshProChildren[0].text = items[i].name;
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

            

            // Optionally, you can add more customization to the new item here
        }

    }
}
