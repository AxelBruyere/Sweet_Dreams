using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEvents : MonoBehaviour
{
    void Start(){ 
        StartCoroutine(onTimer(5));
    }





    private IEnumerator onTimer(int Seconds)
    {

        while (true){
        //Pause during input time then execute the action
            yield return new WaitForSeconds(Seconds);
            Debug.Log("Monster's Coming" + Time.time);
        }
        
        //do things
    }

}
