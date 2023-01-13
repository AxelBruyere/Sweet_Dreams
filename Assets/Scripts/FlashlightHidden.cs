using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHidden : MonoBehaviour
{
    //bool to indicate if flashlight is on/off
    private bool flashlightActive = true;
    public Camera cameraHidden;
    public GameObject flashlightHidden;
    public TimeEvents timeEvent;

    //turn off the flashlight in the beggining
    void Start()
    {
        flashlightHidden.SetActive(false);
    }

    //check if the key to turn on/off the flashlight is pressed
    void Update()
    {   
        if (cameraHidden.enabled){
            if(Input.GetKeyDown(KeyCode.F)){
                if(!flashlightActive){
                    //turn on the flashlight
                    flashlightHidden.SetActive(true);
                    flashlightActive = true;
                    if (timeEvent.monsterHere){ 
                        Debug.Log("Perdu !");
                    }
                    

                }

                else{
                    //turn off the flashlight
                    flashlightHidden.SetActive(false);
                    flashlightActive = false;  
                    
                }
            }
        }
    }

    

}
