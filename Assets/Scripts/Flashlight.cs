using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlightLight;
    //bool to indicate if flashlight is on/off
    public bool flashlightActive = false;
    public static bool flashlightstate = false;

    public GameObject monster;

    //turn off the flashlight in the beggining
    void Start()
    {
        flashlightstate = false;
        flashlightLight.gameObject.SetActive(false);
    }

    //check if the key to turn on/off the flashlight is pressed
    void Update()
    {
        flashlightActive = flashlightstate;
        if(Input.GetKeyDown(KeyCode.F)){
            if(flashlightActive == false){
                //turn on the flashlight
                flashlightLight.gameObject.SetActive(true);
                //flashlightActive = true;
                flashlightstate = true;
            }else{
                //turn off the flashlight
                flashlightLight.gameObject.SetActive(false);
                //flashlightActive = false;  
                flashlightstate = false;
            }
        }
    }
}
