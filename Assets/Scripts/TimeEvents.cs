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
        StartCoroutine(monsterAppearance(3,1,2));
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
                animHidden.enabled = true; //Triggers blinking light animation
                while (animHidden.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0){
                    yield return new WaitForSeconds(0.1f); //Waits for animation end
                }
                monsterHidden.SetActive(true); //Makes the monster appears
                animHidden.enabled = false; //Disables animation
                
                //////////////////////////////////////////////
                //////////////////////////////////////////////hidingCamera.GetComponent<LookWithMouse>().enabled = false; //Disables camera movements
                /////////////////////////////////////////////

                yield return new WaitForSeconds(0.4f); //Waits a few frames
                flashlightHidden.GetComponent<Light>().intensity = 100.0f; //Makes the light turns back on 

            }

            /*If you're not hidden and the light is on when the monster arrives */
            if (!hidingCamera.enabled && flashlightNotHidden.activeSelf){
                animNotHidden.enabled = true; //Triggers blinking light animation
                while (animNotHidden.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0){
                    yield return new WaitForSeconds(0.1f); //Waits for animation end
                }
                monsterNotHidden.SetActive(true); //Makes the monster appears
                animNotHidden.enabled = false; // Disables animation
                mainCamera.GetComponent<LookWithMouse>().enabled = false; //Disables camera movements
                transform.GetComponent<PlayerMovement>().enabled = false; //Disables character movements
                Debug.Log(mainCamera.transform.eulerAngles.y);

                mainCamera.transform.eulerAngles = new Vector3(-30.0f,mainCamera.transform.eulerAngles.y,mainCamera.transform.eulerAngles.z); //Rotates the camera in order to see the monster
                yield return new WaitForSeconds(0.4f); //Waits a few frames
                flashlightNotHidden.GetComponent<Light>().intensity = 100.0f; //Makes the light turns back on
            }


            /*If you're not hidden and the light is off when the monster arrives */



            /*If you're hidden and the light is off when the monster arrives */




            else{
                
            /*wait for the monster leaving : you can get out of the hiding area */
                yield return new WaitForSeconds(timeBeforeLeaving);
                monsterHere = false;
                monsterHidden.SetActive(false); 
            }

        }
        
        //do things
    }

    void hiddenLightOn(){
        
    }


}
