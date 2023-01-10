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
    public bool justHide = false;
    public static bool isHidingWardrobe = false;
    //private bool guiShow = false;
    //show door text and button for door that are interactable
    public GameObject hideDisplay;
    public GameObject hideText;
    public GameObject leaveDisplay;
    public GameObject leaveText;
    public GameObject theHidingPlace;
    public bool isFlashLightOn;
    public GameObject flashlight;
    public GameObject character;

    void Start()
    {
        //set the active camera
        mainCamera.enabled = true;
        hidingCamera.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        //get the active/inactive state of the flashlight
        isFlashLightOn = flashlight.activeInHierarchy;
        //update the discance from the player to the target every interaction
        theDistance = PlayerCasting.DistanceFromTarget;
        //TODO - dont working
        if(isHiding){
            if(Input.GetButtonDown("Action")){
                //Enable player
                //GameObject.Find("PlayerControllerFPS Variant 1").transform.GetChild(0).SetActive(true);                
                character.transform.GetChild(0).gameObject.SetActive(true);

                //Switch cameras
                mainCamera.enabled = true;
                hidingCamera.enabled = false;

                isHiding = false;
                justHide = false;
                isHidingWardrobe = false;

                leaveDisplay.SetActive(false);
                leaveText.SetActive(false);
            }
        }else{
            isHiding = justHide;
            Wait();
        }
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
                    //GameObject.Find("PlayerControllerFPS Variant 1").transform.GetChild(0).SetActive(false);
                    character.transform.GetChild(0).gameObject.SetActive(false);

                    //Switch cameras
                    mainCamera.enabled = false;
                    hidingCamera.enabled = true;

                    //flashlight.SetActive(false);
                    //isFlashLightOn = false;

                    justHide = true;
                    isHidingWardrobe = true;
    
                    hideDisplay.SetActive(false);
                    hideText.SetActive(false);
                    leaveDisplay.SetActive(true);
                    leaveText.SetActive(true);
                    
                    //onInteract.Invoke();
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}