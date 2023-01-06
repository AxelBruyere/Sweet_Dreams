 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w");
        //if player presses w key
        if(!isWalking && forwardPressed){
            //then set isWalking bool to true
            animator.SetBool("isWalking",true);
        }
        //if w not pressed 
        if(isWalking && !forwardPressed){
            //then set isWalking bool to false
            animator.SetBool("isWalking",false);
        }
        
    }
}
