using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{  
    public Item Item;

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        if (Item.itemName == "Monkey")
        {
            InventoryManager.haveMonkey = true;
        }

        if (Item.itemName == "Rabbit")
        {
            InventoryManager.haveRabbit = true;
        }

        if (Item.itemName == "Elephant")
        {
            InventoryManager.haveElephant = true;
        }

        if (Item.itemName == "Dinosaur")
        {
            InventoryManager.haveDinosaur = true;
        }

        if (Item.itemName == "Alligator")
        {
            InventoryManager.haveAlligator = true;
        }
        
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
