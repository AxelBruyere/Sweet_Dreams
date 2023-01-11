#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWithMouse : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public static float sendX;
    public static float sendY;

    public Transform playerBody;

    float xRotation = 0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
#if ENABLE_INPUT_SYSTEM
        float mouseX = 0, mouseY = 0;

        if (Mouse.current != null)
        {
            var delta = Mouse.current.delta.ReadValue() / 10.0f;
            mouseX += delta.x;
            mouseY += delta.y;
        }
        if (Gamepad.current != null)
        {
            var value = Gamepad.current.rightStick.ReadValue() * 2;
            mouseX += value.x;
            mouseY += value.y;
        }

        mouseX *= mouseSensitivity * Time.deltaTime;
        mouseY *= mouseSensitivity * Time.deltaTime;
#else
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
#endif
        sendX = mouseX;
        sendY = mouseY;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -69f, 69f);

        Debug.Log(xRotation);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Debug.Log(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
