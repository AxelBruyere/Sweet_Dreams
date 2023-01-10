using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;

public class PlayerCasting : MonoBehaviour
{
    //distance used in script DoorCell to check if player is in appropriate distance to interact with door
    public static float DistanceFromTarget;
    //distance calculated to the target
    public float ToTarget;

    //public GameObject ActionDisplay;
    //public GameObject ActionText;

    //unity event
    //public UnityEvent onInteract;

    // Update is called once per frame
    void Update()
    {
        //Structure used to get information back from a raycast.
        RaycastHit Hit;
        //returns true if the ray intersects with a collider
        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit)){
        /*if(Hit.transform.tag == "Door"){
            if(DistanceFromTarget <= 3){
                //show text and button
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
            }else{
                //hide text and button
                //Debug.Log("exitdistance");
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
            }

           /* //get the action key
            if(Input.GetButtonDown("Action")){
                if(DistanceFromTarget <= 3){
                    onInteract.Invoke();
                }
            }
        }else{
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }*/
            
            //update distance calculated
            ToTarget = Hit.distance;
            //update distance send to DoorCell
            DistanceFromTarget = ToTarget;
        }
    }
}
