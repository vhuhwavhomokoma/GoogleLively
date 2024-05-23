using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    //The positions of items in the user's virtual room
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

    //Instatiate Room user inventory items to populate the Virtual Room
    private void populateRoom()
    {

        GameObject[] inventoryItems = Resources.LoadAll<GameObject>("UserInventory");

        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i].CompareTag("Cupboard"))
            {
                Instantiate(inventoryItems[i], cupboardposition);
            }

            if (inventoryItems[i].CompareTag("Fridge"))
            {
                Instantiate(inventoryItems[i], fridgepostion);
            }


            if (inventoryItems[i].CompareTag("Cabinet"))
            {
                Instantiate(inventoryItems[i], cabinetposition);
            }


            if (inventoryItems[i].CompareTag("Canvas1"))
            {
                Instantiate(inventoryItems[i], canvasposition1);
            }


            if (inventoryItems[i].CompareTag("Canvas2"))
            {
                Instantiate(inventoryItems[i], canvasposition2);
            }

            if (inventoryItems[i].CompareTag("Chair"))
            {
                Instantiate(inventoryItems[i], chairposition);
            }

            if (inventoryItems[i].CompareTag("Stove"))
            {
                Instantiate(inventoryItems[i], stoveposition);
            }


        }
    }
}
