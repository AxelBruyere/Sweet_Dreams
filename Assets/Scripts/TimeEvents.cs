using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TimeEvents : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hidingCamera;

    public GameObject monster;

    public bool monsterHere = false;
    
    
    void Start(){ 
        StartCoroutine(monsterAppearance(2,1,10));
    }





    private IEnumerator monsterAppearance(int monsterFrequency, int timeToHide, int timeBeforeLeaving)
    {
        while (true){
            /*Monster's Arrival*/
            yield return new WaitForSeconds(monsterFrequency);
            Debug.Log("Monster's Coming" + Time.time);

            /*Monster's here : if you're not hidden, you lose*/
            yield return new WaitForSeconds(timeToHide);
            monsterHere = true;
            if (mainCamera.enabled){
                Debug.Log(" You Lost");
            }
            
            else{
                monster.SetActive(true);
            /*wait for the monster leaving : you can get out of the hiding area */
                yield return new WaitForSeconds(timeBeforeLeaving);
                monsterHere = false;
                monster.SetActive(false);
                Debug.Log("Monster's gone");
            }

        }
        
        //do things
    }


}
