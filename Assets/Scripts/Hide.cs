using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Hide : MonoBehaviour
{  
    //camera control
    public Camera mainCamera;
    public Camera hidingCamera;

    //unity event
    public UnityEvent onInteract;
    //distance player - targer
    public float theDistance;
    //Boolean containing the hidding state
    public bool isHiding = false;
    //private bool guiShow = false;
    //show door text and button for door that are interactable
    public GameObject hideDisplay;
    public GameObject hideText;
    public GameObject theHidingPlace;
    public bool isFlashLightOn;
    public GameObject flashlight;

    void Start()
    {
        //set the active camera
        mainCamera.enabled = true;
        hidingCamera.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        //TODO - dont working
        if(isHiding){
            if(Input.GetButtonDown("E")){
                //Enable player
                GameObject.Find("PlayerControllerFPS Variant 1").SetActive(true);                
                
                //Switch cameras
                mainCamera.enabled = true;
                hidingCamera.enabled = false;

                isHiding = false;
            }
        }
        //get the active/inactive state of the flashlight
        isFlashLightOn = flashlight.activeInHierarchy;
        //update the discance from the player to the target every interaction
        theDistance = PlayerCasting.DistanceFromTarget;
    }

    //function if the mouse is pointing the door
    void OnMouseOver(){
        if (!isHiding){
            if(theDistance <= 3){
                //guiShow = true;
                //show text and button
                hideDisplay.SetActive(true);
                hideText.SetActive(true);
            
                //get the action key
                if(Input.GetButtonDown("Action")){
                    //Disable player
                    GameObject.Find("PlayerControllerFPS Variant 1").SetActive(false);
                    
                    //Switch cameras
                    mainCamera.enabled = false;
                    hidingCamera.enabled = true;

                    //flashlight.SetActive(false);
                    //isFlashLightOn = false;

                    isHiding = true;
                    hideDisplay.SetActive(false);
                    hideText.SetActive(false);
                    
                    //onInteract.Invoke();

                    Debug.Log("Chuicaché");
                }
            }else{
                //hide text and button
                hideDisplay.SetActive(false);
                hideText.SetActive(false);
            }
        }
    }
    
    //function if the mouse is not pointing anymore
    void OnMouseExit(){
        //hide text and button
        hideDisplay.SetActive(false);
        hideText.SetActive(false);
    }
}