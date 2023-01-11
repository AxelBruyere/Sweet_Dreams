using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animationStateController : MonoBehaviour
{
    public Vector3 movement;
    public Vector3 velocity;
    public Vector2 turn;
    public float mouseSensitivity = 200;
    float xRotation = 0f;

    //declare reference variables
    PlayerKeyBindings keyBindings;
    //CharacterController characterController;
    Animator animator;
    public Transform bone;
    
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
        //characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
        keyBindings.CharacterControls.Move.started += onMovementInput;
        keyBindings.CharacterControls.Move.canceled += onMovementInput;
        keyBindings.CharacterControls.Move.performed += onMovementInput;

        bone = GetComponent<Transform>().Find("mixamorig6:Hips/mixamorig6:Spine/mixamorig6:Spine1/mixamorig6:Spine2/mixamorig6:Neck");
    }

    void handleRotation()
    {
       
        turn.x = LookWithMouse.sendX;
        turn.y = LookWithMouse.sendY;
        xRotation -= turn.y;
        xRotation = Mathf.Clamp(xRotation, -69f, 69f);
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
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);

        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
        handleAnimation();
        movement = PlayerMovement.speedtosend;
        //characterController.Move(movement);
        velocity = PlayerMovement.velocitytosend;
        //characterController.Move(velocity * Time.deltaTime);
        Vector3 pos = GameObject.Find("PlayerControllerFPS Variant 1").transform.position;
        GameObject.Find("PlayerControllerFPS Variant 1").transform.GetChild(0).position = new Vector3(pos.x,GameObject.Find("PlayerControllerFPS Variant 1").transform.GetChild(0).position.y,pos.z);
    }

    void LateUpdate()
    {
        bone.localRotation = Quaternion.Euler(xRotation,0f,0f);
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
