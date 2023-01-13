using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPickup : MonoBehaviour
{  
    public Item itemPicked;
    public InventoryManager inventory;
    public GameObject player;
    public GameObject PlushScene;
    public bool MeshPlush;

    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.transform.Find("InventoryManager").GetComponent<InventoryManager>();
        PlushScene = GameObject.FindWithTag("Plush");
        Debug.Log(PlushScene.name);
        if (PlushScene.name == "Monkey" && InventoryManager.haveMonkey == true)
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }

        if (PlushScene.name == "Rabbit" && InventoryManager.haveRabbit == true)
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }

        if (PlushScene.name == "Elephant" && InventoryManager.haveElephant == true)
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }

        if (PlushScene.name == "Dinossaur" && InventoryManager.haveDinosaur == true)
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }

        if (PlushScene.name == "Alligator" && InventoryManager.haveAlligator == true)
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        MeshPlush = PlushScene.transform.GetComponent<MeshRenderer>().enabled;
    }

    void Pickup()
    {
        if (itemPicked.itemName == "Monkey" && InventoryManager.haveMonkey == false)
        {
            inventory.Add(itemPicked);
            InventoryManager.haveMonkey = true;
        }

        if (itemPicked.itemName == "Rabbit" && InventoryManager.haveRabbit == false)
        {
            inventory.Add(itemPicked);
            InventoryManager.haveRabbit = true;
        }

        if (itemPicked.itemName == "Elephant" && InventoryManager.haveElephant == false)
        {
            inventory.Add(itemPicked);
            InventoryManager.haveElephant = true;
        }

        if (itemPicked.itemName == "Dinossaur" && InventoryManager.haveDinosaur == false)
        {
            inventory.Add(itemPicked);
            InventoryManager.haveDinosaur = true;
        }

        if (itemPicked.itemName == "Alligator" && InventoryManager.haveAlligator == false)
        {
            inventory.Add(itemPicked);
            InventoryManager.haveAlligator = true;
        }
        
        gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnMouseDown()
    {
        if(MeshPlush)
        {
            Pickup();
        }
    }
}
