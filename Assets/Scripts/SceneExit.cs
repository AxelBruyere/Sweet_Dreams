using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{   
    GameObject Player;
    float gravity;
    //Name of the piece of the house the player is leaving
    public string exitName;

    void Awake(){
        Player = GameObject.FindWithTag("Player");
        gravity = Player.GetComponent<PlayerMovement>().gravity;
    }

    //function called when button action is called
    public void ButonMoveScene(string sceneToLoad){
        if(Player != null){
            gravity = 0.0f;
            Destroy(Player.GetComponent<TimeEvents>());
        }
        //Change the name of the last exit name for the actual piece
        PlayerPrefs.SetString("LastExitName", exitName);
        //load the scene indicated in the door parameter
        SceneManager.LoadScene(sceneToLoad);
    }
}
