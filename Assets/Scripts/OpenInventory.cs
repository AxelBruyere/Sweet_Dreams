using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    //bool to verify if the game is paused or not
    public static bool InventoryIsOpen = false;

    //game object that indicate the open inventory in unity
    public GameObject InventoryUI;

    void Start()
    {
        //At the beginning inventory is closed
        InventoryUI.SetActive(false);
    }

    void Update()
    {
        //key I to open inventory
        if(Input.GetKeyDown(KeyCode.I)){
            if(!InventoryIsOpen)
            {
                InventoryOpen();
            }
            else{
                InventoryClose();
            }
        }
    }

    //fonction to open
    public void InventoryOpen(){
        //show the inventory menu
        InventoryUI.SetActive(true);
        //stop the time flow
        Time.timeScale = 0f;
        //bool to true to indicate that the inventory is open
        InventoryIsOpen = true;
        //free the cursor
        Cursor.lockState = CursorLockMode.None;
        //show the cursor
        Cursor.visible = true;
    }

    //fonction to resume the game
    public void InventoryClose(){
        //hide the pause menu
        InventoryUI.SetActive(false);
        //reactive the time flow
        Time.timeScale = 1f;
        //bool to false to indicate that the game is running
        InventoryIsOpen = false;
        //lock the cursor in the game area
        Cursor.lockState = CursorLockMode.Locked;
        //hide the cursor
        Cursor.visible = false;
    }
}