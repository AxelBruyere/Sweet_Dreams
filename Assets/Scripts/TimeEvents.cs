using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TimeEvents : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hidingCamera;

    public GameObject monsterHidden;
    public GameObject flashlightHidden;
    public Animator animHidden;

    public GameObject monsterNotHidden;
    public GameObject flashlightNotHidden;
    public Animator animNotHidden;

    public bool monsterHere = false;
    

    
    void Start(){ 
        StartCoroutine(monsterAppearance(5,5,5));
        animHidden = flashlightHidden.GetComponent<Animator>();
        animNotHidden = flashlightNotHidden.GetComponent<Animator>();
    }





    private IEnumerator monsterAppearance(int monsterFrequency, int timeToHide, int timeBeforeLeaving)
    {
        while (true){
            /*Monster's Arrival*/
            yield return new WaitForSeconds(monsterFrequency);
            Debug.Log("Coming");
            /*Monster's here : if you're not hidden, you lose*/
            yield return new WaitForSeconds(timeToHide);
            

            /*If you're hidden with the light on when the monster arrives */
            if (hidingCamera.enabled && flashlightHidden.activeSelf){
                flashlightHidden.GetComponent<FlashlightHidden>().enabled = false;//Disable flashlight controls
                animHidden.enabled = true; //Triggers blinking light animation
                while (animHidden.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0){
                    yield return new WaitForSeconds(0.1f); //Waits for animation end
                }
                monsterHidden.SetActive(true); //Makes the monster appears
                animHidden.enabled = false; //Disables animation
                
                //////////////////////////////////////////////
                //////////////////////////////////////////////hidingCamera.GetComponent<LookWithMouse>().enabled = false; //Disables camera movements
                /////////////////////////////////////////////
                hidingCamera.transform.eulerAngles = new Vector3(0.0f,0.0f,0.0f);
                yield return new WaitForSeconds(0.4f); //Waits a few frames
                flashlightHidden.GetComponent<Light>().intensity = 100.0f; //Makes the light turns back on 

            }

            /*If you're not hidden and the light is on when the monster arrives */
            if (!hidingCamera.enabled && flashlightNotHidden.activeSelf){
                transform.GetComponent<Flashlight>().enabled = false;//Disable flashlight controls
                animNotHidden.enabled = true; //Triggers blinking light animation
                while (animNotHidden.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0){
                    yield return new WaitForSeconds(0.1f); //Waits for animation end
                }
                monsterNotHidden.SetActive(true); //Makes the monster appears
                animNotHidden.enabled = false; // Disables animation
                mainCamera.GetComponent<LookWithMouse>().enabled = false; //Disables camera movements
                transform.GetComponent<PlayerMovement>().enabled = false; //Disables character movements
                mainCamera.transform.eulerAngles = new Vector3(-30.0f,mainCamera.transform.eulerAngles.y,mainCamera.transform.eulerAngles.z); //Rotates the camera in order to see the monster
                yield return new WaitForSeconds(0.4f); //Waits a few frames
                flashlightNotHidden.GetComponent<Light>().intensity = 100.0f; //Makes the light turns back on
            }


            /*If you're not hidden and the light is off when the monster arrives */
            if (!hidingCamera.enabled && !flashlightNotHidden.activeSelf){
                mainCamera.GetComponent<LookWithMouse>().enabled = false; //Disables camera movements
                transform.GetComponent<PlayerMovement>().enabled = false; //Disables character movements
                flashlightNotHidden.GetComponent<FlashlightHidden>().enabled = false;//Disable flashlight controls

                monsterNotHidden.SetActive(true); //Makes the monster appears
                mainCamera.transform.eulerAngles = new Vector3(-30.0f,mainCamera.transform.eulerAngles.y,mainCamera.transform.eulerAngles.z); //Rotates the camera in order to see the monster
                flashlightNotHidden.SetActive(true);//Active the flashlight
            }


            /*If you're hidden and the light is off when the monster arrives */
            if (hidingCamera.enabled && !flashlightHidden.activeSelf){
                monsterHidden.SetActive(true); //Makes the monster appears in order to have it in front of the player in case he/she turns the light back on
                monsterHere = true; //Useful to manage the case the players turns de light back on before the monster leaves
                yield return new WaitForSeconds(timeBeforeLeaving); //Waits until the monster leaves
                monsterHere = false; 
                monsterHidden.SetActive(false); //Makes the monster disappears
            }


        }
        
    }


}
