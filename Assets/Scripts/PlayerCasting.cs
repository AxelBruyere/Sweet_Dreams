using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    //distance used in script DoorCell to check if player is in appropriate distance to interact with door
    public static float DistanceFromTarget;
    //distance calculated to the target
    public float ToTarget;

    // Update is called once per frame
    void Update()
    {
        //Structure used to get information back from a raycast.
        RaycastHit Hit;
        //returns true if the ray intersects with a collider
        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {        
            //update distance calculated
            ToTarget = Hit.distance;
            //update distance send to DoorCell
            DistanceFromTarget = ToTarget;
        }
    }
}
