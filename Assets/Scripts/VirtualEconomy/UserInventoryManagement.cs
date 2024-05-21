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
        string prefabsFolder = "Assets/Prefabs/UserInventory";
        List<GameObject> items = new List<GameObject>();
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new[] { prefabsFolder });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
            if (prefab != null)
            {
                items.Add(prefab);
            }
        }


  
    
        
        for (int i = 0; i < items.Count; i++)
        {
            // Calculate the position for the new item based on index
            float yOffset = i * 2 * itemSpacing; 

            Texture previewTexture = AssetPreview.GetAssetPreview(items[i]);


            
            GameObject newItem = Instantiate(userinventoryEntry, entryParent);
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

        }

    }
}
