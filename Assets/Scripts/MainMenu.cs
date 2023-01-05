using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    SceneExit exit;
    public void PlayGame(){
        exit = gameObject.GetComponent<SceneExit>();
        exit.ButonMoveScene("ChildRoom");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
