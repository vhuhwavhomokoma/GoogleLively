using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{

    public Transform cupboardposition;

    public Transform fridgepostion;
    // Start is called before the first frame update
    void Start()
    {
        populateRoom();
    }

    private void populateRoom()
    {
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
            if (items[i].CompareTag("Cupboard"))
            {
                Instantiate(items[i], cupboardposition);
            }

            if (items[i].CompareTag("Fridge"))
            {
                Instantiate(items[i], fridgepostion);
            }
        }
    }
}
