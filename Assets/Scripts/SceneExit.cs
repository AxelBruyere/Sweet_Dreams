using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    
    private void OnTriggerEnter(Collider other){ //Change func
        SceneManager.LoadScene(sceneToLoad);
    }
}
