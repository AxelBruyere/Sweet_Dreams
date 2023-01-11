using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWardrobe : MonoBehaviour
{
    public GameObject wardrobe;
    public GameObject door1;
    public GameObject door2;

    // Update is called once per frame
    void Update()
    {
        if(Hide.isHidingWardrobe){
            door1.SetActive(true);
            door2.SetActive(true);
            wardrobe.GetComponent<MeshRenderer>().enabled = false;
        }
        else{
            door1.SetActive(false);
            door2.SetActive(false);
            wardrobe.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }
}
