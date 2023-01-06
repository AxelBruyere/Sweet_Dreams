using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float Sensitivity = 2.0f;
    public float Vert;
    public float Hor;
    public float Speed = 5.0f;

    public Vector3 Movement;
    public float VertTemp;

    public GameObject groundCheck;
    public float groundDistance;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;    
    }

    // Update is called once per frame
    void Update()
    {
        Vert += Sensitivity * Input.GetAxis("Mouse X");
        Hor -= Sensitivity * Input.GetAxis("Mouse Y");
        Debug.Log("MouseX : " + Input.GetAxis("Mouse X"));
        Debug.Log("MouseY : " + Input.GetAxis("Mouse Y"));
        
        //transform.localRotation = Quaternion.Euler(-Hor,0,0);

        transform.eulerAngles = new Vector3(-Hor,Vert,0.0f);

        //transform.Rotate(new Vector3(Hor,Vert,0.0f),Space.Self);

        /*if (Input.GetKey("z")){
            Movement = Vector3.forward;
        }
        if (Input.GetKey("s")){
            Movement = -Vector3.forward;
        }
        if (Input.GetKey("q")){
            Movement = -Vector3.right;
        }
        if (Input.GetKey("d")){
            Movement = Vector3.right;
        }
        //Movement.y *= 0;

        //this.transform.Translate(Movement * Speed * Time.deltaTime);

        Debug.Log("Movement : "+Movement*Speed*Time.deltaTime);

        //Movement *= 0;*/
    }
}
