using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHidden : MonoBehaviour
{
    //bool to indicate if flashlight is on/off
    private bool flashlightActive = false;
    public Camera cameraHidden;
    public GameObject PlayerControllerFPS;

    //turn off the flashlight in the beggining
    void Start()
    {
        transform.gameObject.SetActive(false);
    }

    //check if the key to turn on/off the flashlight is pressed
    void Update()
    {   
        if (cameraHidden.enabled){
            if(Input.GetKeyDown(KeyCode.F)){
                if(flashlightActive == false){
                    //turn on the flashlight
                    transform.gameObject.SetActive(true);
                    flashlightActive = true;

                }

                else{
                    //turn off the flashlight
                    transform.gameObject.SetActive(false);
                    flashlightActive = false;  
                }
            }
        }
    }

    

}
