using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    private InventoryManager inventory;
    private GameObject player;
    private GameObject plush;
    private GameObject[] listSlots;

    [SerializeField] private GameObject slot;

    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.transform.Find("InventoryManager").GetComponent<InventoryManager>();
        plush = inventory.PlushScene;

    }

    public void Selection()
    {
        // Create a temporary reference to the current scene
        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of the scene
        string sceneName = currentScene.name;
        string slotName = slot.transform.Find("Text").GetComponent<Text>().text;

        if (sceneName == "Attic")
        {
            if (slotName == "Monkey") //&& scene = Attic
            {
                Debug.Log(plush.transform.GetComponent<MeshRenderer>().enabled);
                plush.transform.GetComponent<MeshRenderer>().enabled=true;
                
                inventory.Remove(plush.GetComponent<ItemControler>().Item);
                InventoryManager.haveMonkey = false;

            }
                

            //else if ((plush = rabbit) ||(plush = alligator)) && scene = LivingRoomAndKitchen
                //rabbit.SetActive(true) || alligator.SetActive(true)

            //else if plush = dinossaur && scene = office
                //Monkey.SetActive(true)

            //else if plush = elephant && scene = Bathroom
                //Monkey.SetActive(true)
            //inventory.Remove(itemPut)
        }
        else{
             Debug.Log("You can't");
        }
    }
}