using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //bool to verify if the game is paused or not
    public static bool GameIsPaused = false;

    //game object that indicate the pause menu in unity
    public GameObject pauseMenuUI;

    void Update()
    {
        //key P for pause the game
        if(Input.GetKeyDown(KeyCode.P)){
            if(GameIsPaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }

    //fonction to resume the game
    public void Resume(){
        //hide the pause menu
        pauseMenuUI.SetActive(false);
        //reactive the time flow
        Time.timeScale = 1f;
        //bool to false to indicate that the game is running
        GameIsPaused = false;
        //lock the cursor in the game area
        Cursor.lockState = CursorLockMode.Locked;
        //hide the cursor
        Cursor.visible = false;
    }

    //function to pause the game
    void Pause(){
        //show the pause menu
        pauseMenuUI.SetActive(true);
        //stop the time flow
        Time.timeScale = 0f;
        //bool to true to indicate that the game is paused
        GameIsPaused = true;
        //free the cursor
        Cursor.lockState = CursorLockMode.None;
        //show the cursor
        Cursor.visible = true;
    }

    //function called when Menu button is pressed
    public void LoadMenu(){
        GameObject toDestroy = GameObject.FindWithTag("Player");
        InventoryManager.haveMonkey = false;
        InventoryManager.haveRabbit = false;
        InventoryManager.haveDinosaur = false;
        InventoryManager.haveAlligator = false;
        InventoryManager.haveElephant = false;
        Destroy(toDestroy);
        //reactive the time flow
        Time.timeScale = 1f;
        //load of the first scene in the order - the menu
        SceneManager.LoadScene(0);
    }

    //function called when quit button is pressed, in software just message in the console
    public void QuitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}