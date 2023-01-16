using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashlightHidden : MonoBehaviour
{
    //bool to indicate if flashlight is on/off
    private bool flashlightActive = true;
    public Camera cameraHidden;
    public GameObject flashlightHidden;
    public TimeEvents timeEvent;

    public AudioSource Screamer;
    public bool dead;

    //turn off the flashlight in the beggining
    void Start()
    {
        flashlightHidden.SetActive(false);
        cameraHidden = GameObject.Find("CameraHide").GetComponent<Camera>();
        flashlightHidden = GameObject.Find("Flashlight Hidden");
    }

    //check if the key to turn on/off the flashlight is pressed
    void Update()
    {   
        if (cameraHidden.enabled){
            if(dead && !Screamer.isPlaying){
                SceneManager.LoadScene(7);
                GetComponent<FlashlightHidden>().enabled = false;
            }
            if(Input.GetKeyDown(KeyCode.F)){
                if(!flashlightActive){
                    //turn on the flashlight
                    flashlightHidden.SetActive(true);
                    flashlightActive = true;
                    if (timeEvent.monsterHere){ 
                        Screamer.Play();
                        dead = true;
                        GetComponent<TimeEvents>().enabled = false;
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
