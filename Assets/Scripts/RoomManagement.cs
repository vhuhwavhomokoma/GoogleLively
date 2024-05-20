using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{

    public Transform cupboardposition;

    public Transform fridgepostion;

    public Transform canvasposition1;

    public Transform canvasposition2;

    public Transform cabinetposition;

    public Transform chairposition;

    public Transform stoveposition;

   
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


            if (items[i].CompareTag("Cabinet"))
            {
                Instantiate(items[i], cabinetposition);
            }


            if (items[i].CompareTag("Canvas1"))
            {
                Instantiate(items[i], canvasposition1);
            }


            if (items[i].CompareTag("Canvas2"))
            {
                Instantiate(items[i], canvasposition2);
            }

            if (items[i].CompareTag("Chair"))
            {
                Instantiate(items[i], chairposition);
            }

            if (items[i].CompareTag("Stove"))
            {
                Instantiate(items[i], stoveposition);
            }


        }
    }
}
