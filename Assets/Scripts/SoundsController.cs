using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public AudioSource footStepSound;
    public AudioSource FlashlightSound;
    public AudioSource InventorySound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))
        {
            footStepSound.enabled = true;
        }
        else if(Input.GetKey(KeyCode.F))
        {
            FlashlightSound.enabled = true;
        }
        else
        {
            footStepSound.enabled = false;
            FlashlightSound.enabled = false;
        }
    }

    void onMouseDown(){
        InventorySound.enabled = true;
    }
}
