using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Criation of a player instance to keep it characteristics between scenes
    public static PlayerScript instance;
    
    void Start()
    {
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
