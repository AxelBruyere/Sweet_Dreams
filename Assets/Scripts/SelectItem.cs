using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectItem : MonoBehaviour
{
    public Item itemPut;
    public InventoryManager inventory;
    public GameObject player;
    private GameObject PlushScene;
    private GameObject listSlots;

    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.transform.Find("InventoryManager").GetComponent<InventoryManager>();
        listSlots = player.transform.Find("CanvasInventory2").gameObject.transform.Find("InventoryPanel").gameObject.transform.Find("Slots").gameObject;
    }

    public void Selection()
    {
        // Create a temporary reference to the current scene
        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of the scene
        string sceneName = currentScene.name;

        //listSlots = inventory.GetComponent<Slots>();

        Debug.Log(listSlots);

        if (sceneName == "Childroom")
        {
            Debug.Log("You can");
            //if plush = monkey && scene = Attic
                //Monkey.SetActive(true)

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