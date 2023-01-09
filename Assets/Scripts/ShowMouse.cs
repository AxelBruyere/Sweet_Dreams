using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMouse : MonoBehaviour
{
    //bool to verify if the game is paused or not
    public static bool Mouse = false;

    void Update()
    {
        //key P for pause the game
        if(Input.GetKeyDown(KeyCode.A)){
            if(Mouse)
            {
                //hide the cursor
                Cursor.visible = false;
                Mouse = false;
            }else{
                Cursor.visible = true;
                Mouse = true;
            }
        }
    }
}