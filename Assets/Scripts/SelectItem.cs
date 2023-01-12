using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectItem : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Selection()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();
 
        // Retrieve the name of t$$anonymous$$s scene.
        string sceneName = currentScene.name;

        if (sceneName == "Childroom")
        {
            Debug.Log("plush can be puted down");
        }
        else{
             Debug.Log("you can't put the plush down here");
        }
    }
}