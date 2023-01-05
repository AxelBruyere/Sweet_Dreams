using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    //Name of the last piece that the player was
    public string lastExitName;
    // Start is called before the first frame update
    void Start()
    {   
        //when game starts player is in the childroom 
        if(PlayerPrefs.GetString("LastExitName") == "MainMenu")
        {
           //TODO
           //get position of spawn point main menu of the object
        }  
        //when player change room 
        else if(PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            //get information of the spawn point to put the player in that position looking front
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }
}
