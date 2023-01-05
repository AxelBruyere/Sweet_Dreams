using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float Sensitivity = 2.0f;
    public float Vert;
    public float Hor;
    public float Speed = 5.0f;
    public GameObject groundCheck;
    public float groundDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vert += Sensitivity * Input.GetAxis("Mouse X");
        Hor -= Sensitivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(Hor,Vert,0.0f);
    }
}
