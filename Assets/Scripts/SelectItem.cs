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
        // Create a temporary reference to the current scene
        Scene currentScene0 = SceneManager.GetActiveScene ();
        // Retrieve the name of the scene
        string sceneName0 = currentScene0.name;
        if (sceneName0 != "ChildRoom")
        {
            plush = inventory.PlushScene;
        } 
    }

    public void Selection()
    {
        // Create a temporary reference to the current scene
        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of the scene
        string sceneName = currentScene.name;
        string slotName = slot.transform.Find("Text").GetComponent<Text>().text;
        Debug.Log(slotName);
        if (InventoryManager.haveDinosaur==true && InventoryManager.haveRabbit==true && InventoryManager.haveElephant==true &&InventoryManager.haveAlligator==true && InventoryManager.haveMonkey==true)
        {    
            if (sceneName == "ChildRoom")
            {
                plush = GameObject.Find(slotName);
                if (slotName == "Alligator")
                {
                    foreach (Transform child in plush.transform)
                        {
                            child.gameObject.SetActive(true);
                        }
                    inventory.Remove(plush.GetComponent<ItemControler>().Item);
                }
                else if (slotName == "Elephant" && (sceneName == "Bathroom"||sceneName == "ChildRoom"))
                {
                    foreach (Transform child in plush.transform)
                        {
                            child.gameObject.SetActive(true);
                        }
                    inventory.Remove(plush.GetComponent<ItemControler>().Item);
                }
                else if (slotName == "Rabbit" && (sceneName == "LivingRoomAndKitchen"||sceneName == "ChildRoom"))
                {
                    foreach (Transform child in plush.transform)
                        {
                            child.gameObject.SetActive(true);
                        }
                    inventory.Remove(plush.GetComponent<ItemControler>().Item);
                }
                else if (slotName == "Monkey" && (sceneName == "Attic"||sceneName == "ChildRoom"))
                {
                    plush.transform.GetComponent<MeshRenderer>().enabled=true;
                    inventory.Remove(plush.GetComponent<ItemControler>().Item);
                }
                else if (slotName == "Dinosaur" && (sceneName == "Office"||sceneName == "ChildRoom"))
                {
                    foreach (Transform child in plush.transform)
                        {
                            child.gameObject.SetActive(true);
                        }
                    inventory.Remove(plush.GetComponent<ItemControler>().Item);
                }
            }
            else
            {
                Debug.Log("You can put down the plushes only on the ChildRoom !");
            }
        }
        else 
        {
            Debug.Log("You don't have all the plushes !");
        }
    }
}