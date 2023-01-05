using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //variable to acess function in other script
    SceneExit exit;

    //function when button Play is pressed
    public void PlayGame(){
        //save the script in the variable
        exit = gameObject.GetComponent<SceneExit>();
        //call the function to load scene with the first scene
        exit.ButonMoveScene("ChildRoom");
    }

    //function to close game, in the software just a message in the console
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
