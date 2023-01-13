using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    
    public GameObject Player;


    private void Awake(){
        Player = GameObject.FindWithTag("Player");
        if (Player != null)
            Destroy(Player);
        //lock the cursor in the game area
        Cursor.lockState = CursorLockMode.None;
        //hide the cursor
        Cursor.visible = true;
    }

    //function when button Play is pressed
    public void backToMainMenu(){
        SceneManager.LoadScene(0);
    }

    //function to close game, in the software just a message in the console
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}