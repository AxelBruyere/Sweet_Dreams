using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushesControl : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;

    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    // Update is called once per frame
    void Update()
    {
        // check distance entre obj et joueur
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // si - ou = 2.5 unités de distance = on peut ramasser
        if (dist <= 1.9f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        //si on peut ramasser et qu'on appuye sur T = on porte l'objet
        if (hasPlayer==true && Input.GetKey(KeyCode.T))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        } 
        //si on porte l'objet
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            // clic gauche = on jette l'objet
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            // clic droit = on pose l'objet
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }   
    }
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
