using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlightLight;
    private bool flashlightActive = false;

    // Start is called before the first frame update
    void Start()
    {
        flashlightLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            if(flashlightActive == false){
                flashlightLight.gameObject.SetActive(true);
                flashlightActive = true;
            }else{
                flashlightLight.gameObject.SetActive(false);
                flashlightActive = false;  
            }
        }
    }
}
