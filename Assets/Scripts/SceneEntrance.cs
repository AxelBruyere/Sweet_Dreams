using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public string lastExitName;
    // Start is called before the first frame update
    void Start()
    {    
        if(PlayerPrefs.GetString("LastExitName") == "MainMenu")
        {
           
        }   
        else if(PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }
}
