using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryInstance { get; private set; }

    public List<GameObject> items = new List<GameObject>();

    private void Awake()
    {
        if (inventoryInstance == null)
        {
            inventoryInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(GameObject virtualitem)
    {
        items.Add(virtualitem);
    }

    public void RemoveItem(GameObject virtualitem)
    {
        items.Remove(virtualitem);
    }
}

