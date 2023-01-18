using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    GameObject Player;
    //Name of the last piece that the player was
    public string lastExitName;

    void Awake(){
        Player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {    
        if(Player != null){
            if(!Player.GetComponent<TimeEvents>())
                Player.AddComponent<TimeEvents>();
        }
        //when player changes room 
        if(PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            //get information of the spawn point to put the player in that position looking front
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
        }

        //when game starts player is in the childroom
        else if(PlayerPrefs.GetString("LastExitName") == "MainMenu")
        {
           //TODO
           //get position of spawn point main menu of the object
        } 
    }
}
