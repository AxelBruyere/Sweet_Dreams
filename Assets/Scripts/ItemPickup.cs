using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{  
    public Item itemPicked;
    public InventoryManager inventory;

    public GameObject player;

    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.transform.Find("InventoryManager").GetComponent<InventoryManager>();
        //Debug.Log(inventory);
    }

    void Pickup()
    {
        //Debug.Log(itemPicked);
        inventory.Add(itemPicked);
        if (itemPicked.itemName == "Monkey")
        {
            InventoryManager.haveMonkey = true;
        }

        if (itemPicked.itemName == "Rabbit")
        {
            InventoryManager.haveRabbit = true;
        }

        if (itemPicked.itemName == "Elephant")
        {
            InventoryManager.haveElephant = true;
        }

        if (itemPicked.itemName == "Dinosaur")
        {
            InventoryManager.haveDinosaur = true;
        }

        if (itemPicked.itemName == "Alligator")
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
