using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Hide : MonoBehaviour
{  
    //unity event
    public UnityEvent onInteract;
    //distance player - targer
    public float theDistance;
    //Boolean containing the hidding state
    public bool isHidden;
    //show door text and button for door that are interactable
    public GameObject hideDisplay;
    public GameObject hideText;
    public GameObject theHidingPlace;
    public bool isFlashLightOn;
    public GameObject flashlight;



    // Update is called once per frame
    void Update()
    {
        //get the active/inactive state of the flashlight
        isFlashLightOn = flashlight.activeInHierarchy;
        //update the discance from the player to the target every interaction
        theDistance = PlayerCasting.DistanceFromTarget;
    }

    //function if the mouse is pointing the door
    void OnMouseOver(){
        Debug.Log("Over " + gameObject.name);
        if (!isHidden){
            if(theDistance <= 3){
                //show text and button
                hideDisplay.SetActive(true);
                hideText.SetActive(true);
            }else{
                //hide text and button
                hideDisplay.SetActive(false);
                hideText.SetActive(false);
            }

            //get the action key
            if(Input.GetButtonDown("Action")){
                if(theDistance <= 3){
                    isHidden = true;
                    isFlashLightOn = false;
                    flashlight.SetActive(false);
                    onInteract.Invoke();

                    Debug.Log("Chuicaché");
                }
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