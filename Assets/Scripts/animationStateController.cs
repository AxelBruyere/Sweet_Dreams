 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animationStateController : MonoBehaviour
{
    public Vector3 movement;
    public Vector2 turn;
    public float mouseSensitivity = 200;
    //declare reference variables
    PlayerKeyBindings keyBindings;
    CharacterController characterController;
    Animator animator;
    
    //variables to store player input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    //float rotationFactorPerFrame = 1.0f;

    //called earlier than Start
    void Awake()
    {
        //set reference variable
        keyBindings = new PlayerKeyBindings();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
        keyBindings.CharacterControls.Move.started += onMovementInput;
        keyBindings.CharacterControls.Move.canceled += onMovementInput;
        keyBindings.CharacterControls.Move.performed += onMovementInput;
    }

    void handleRotation()
    {
        turn.x = LookWithMouse.sendX;
        turn.y = LookWithMouse.sendY;
        transform.localRotation = Quaternion.Euler(0f,turn.x,0f);
    }
    
    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleAnimation()
    {
        /*//get parameter value from animator
        bool isWalking = animator.GetBool("isWalking");

        //start walking if movement pressed is true and not already walking
        if(isMovementPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        //stop walking if movement pressed is false and already walking
        else if(!isMovementPressed && isWalking){
            animator.SetBool("isWalking", false);
        }*/
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);

        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //handleRotation();
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        turn.y += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f,turn.x,0f);
        handleAnimation();
        movement = PlayerMovement.speedtosend;
        characterController.Move(movement);

    }

    void OnEnable()
    {
        keyBindings.CharacterControls.Enable();
    }

    void OnDisable()
    {
        keyBindings.CharacterControls.Disable();
    }
}
