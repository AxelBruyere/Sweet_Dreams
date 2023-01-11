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

    public bool monsterHere = false;
    
    public Animator anim;
    public AnimatorStateInfo animStateInfo;

    
    void Start(){ 
        StartCoroutine(monsterAppearance(3,1,2));
        anim = flashlightHidden.GetComponent<Animator>();
    }





    private IEnumerator monsterAppearance(int monsterFrequency, int timeToHide, int timeBeforeLeaving)
    {
        while (true){
            /*Monster's Arrival*/
            yield return new WaitForSeconds(monsterFrequency);
            Debug.Log("Coming");
            /*Monster's here : if you're not hidden, you lose*/
            yield return new WaitForSeconds(timeToHide);
            
            if (hidingCamera.enabled && flashlightHidden.activeSelf){
                Debug.Log("Ouiouioui");
                anim.enabled = true;
                while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0){
                    yield return new WaitForSeconds(0.1f);
                }
                monsterHidden.SetActive(true);
                anim.enabled = false;

                Debug.Log("Monster appeared");
                yield return new WaitForSeconds(0.2f);
                flashlightHidden.GetComponent<Light>().intensity = 100.0f;

                
            }


            
            else{
                
            /*wait for the monster leaving : you can get out of the hiding area */
                yield return new WaitForSeconds(timeBeforeLeaving);
                monsterHere = false;
                monsterHidden.SetActive(false); 
            }

        }
        
        //do things
    }


}
