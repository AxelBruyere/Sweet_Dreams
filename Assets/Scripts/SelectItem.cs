using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    [SerializeField] private GameObject plush;
    [SerializeField] private GameObject slot;
    private GameObject[] listSlots;
    private InventoryManager inventory;
    private GameObject player;

    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.transform.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        plush = inventory.PlushScene;
    }

    public void Selection()
    {
        // Create a temporary reference to the current scene
        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of the scene
        string sceneName = currentScene.name;
        string slotName = slot.transform.Find("Text").GetComponent<Text>().text;

        if (sceneName == "ChildRoom")
        {
            if(slotName == "Monkey")
            {
                plush.transform.GetComponent<MeshRenderer>().enabled=true;
                inventory.Remove(plush.GetComponent<ItemControler>().Item);
                InventoryManager.haveMonkey = false;
            }
            else
            {
                foreach (Transform child in plush.transform)
                {
                    child.gameObject.SetActive(true);
                }
                inventory.Remove(plush.GetComponent<ItemControler>().Item);
                if (slotName == "Alligator")
                {
                    InventoryManager.haveAlligator = false;
                }
                else if (slotName == "Rabbit")
                {
                    InventoryManager.haveRabbit = false;
                }
                else if (slotName == "Dinossaur")
                {
                    InventoryManager.haveDinosaur = false;
                }
                else if (slotName == "Elephant")
                {
                    InventoryManager.haveElephant = false;
                }   
            }
        }
        else if (slotName == "Monkey" && sceneName == "Attic")
        {
            plush.transform.GetComponent<MeshRenderer>().enabled=true;
            inventory.Remove(plush.GetComponent<ItemControler>().Item);
            InventoryManager.haveMonkey = false;
        }

        else if (slotName == "Elephant" && sceneName == "Bathroom")
        {
            foreach (Transform child in plush.transform)
                {
                    child.gameObject.SetActive(true);
                }
            inventory.Remove(plush.GetComponent<ItemControler>().Item);
            InventoryManager.haveElephant = false;
        }

        else if (slotName == "Dinossaur" && sceneName == "Office")
        {
            foreach (Transform child in plush.transform)
                {
                    child.gameObject.SetActive(true);
                }
            inventory.Remove(plush.GetComponent<ItemControler>().Item);
            InventoryManager.haveDinosaur = false;
        }
        
        else if (slotName == "Alligator" && sceneName == "Corridor")
        {
            foreach (Transform child in plush.transform)
                {
                    child.gameObject.SetActive(true);
                }
            inventory.Remove(plush.GetComponent<ItemControler>().Item);
            InventoryManager.haveAlligator = false;
        }

        else if (slotName == "Rabbit" && sceneName == "LivingRoomAndKitchen")
        {
            foreach (Transform child in plush.transform)
                {
                    child.gameObject.SetActive(true);
                }
            inventory.Remove(plush.GetComponent<ItemControler>().Item);
            InventoryManager.haveRabbit = false;
        }

        else{
             Debug.Log("You can't");
        }
    }
}