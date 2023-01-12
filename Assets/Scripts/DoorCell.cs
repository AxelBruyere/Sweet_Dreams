using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DoorCell : MonoBehaviour
{  
    //unity event
    public UnityEvent onInteract;
    //distance player - targer
    public float theDistance;
    //show door text and button for door that are interactable
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject theDoor;
    //door noise
    public AudioSource DoorSound;

    // Update is called once per frame
    void Update()
    {
        //DoorSound.enabled = false;
        //update the discance from the player to the target every interaction
        theDistance = PlayerCasting.DistanceFromTarget;
    }

    //function if the mouse is pointing the door
    void OnMouseOver(){
        
        if(theDistance <= 3){
            //show text and button
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }else{
            //hide text and button
            //Debug.Log("exitdistance");
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }

        //get the action key
        if(Input.GetButtonDown("Action")){
            if(theDistance <= 3){
                DoorSound.Play();
                onInteract.Invoke();
            }
        }
    }
    
    //function if the mouse is not pointing anymore
    void OnMouseExit(){
        //Debug.Log("exit mouse");
        //hide text and button
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
