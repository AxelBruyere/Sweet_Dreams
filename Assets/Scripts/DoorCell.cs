using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DoorCell : MonoBehaviour
{
    public UnityEvent onInteract;
    public float theDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject theDoor;
    //public AudioSource CreakSound;



    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver(){
        if(theDistance <= 3){
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }else{
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }

        if(Input.GetButtonDown("Action")){
            if(theDistance <= 3){
                onInteract.Invoke();
            }
        }
    }
    
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
