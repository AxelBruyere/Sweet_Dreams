using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Hide : MonoBehaviour
{  
    //GameObjects retrieve auto
    //Player
    public GameObject player;
    //Flashlight
    public GameObject flashlight;

    //camera control
    public Camera mainCamera;
    public Camera hidingCamera;

    //audio control
    public AudioListener mainAudio;
    public AudioListener hidingAudio;
    public AudioSource mainMusic;
    public AudioSource hidingMusic;

    //unity event
    public UnityEvent onInteract;
    //distance player - targer
    public float theDistance;
    //Boolean containing the hidding state
    public bool isHiding = false;
    public bool justHide = false;
    public static bool isHidingWardrobe = false;
    //private bool guiShow = false;
    //show door text and button for door that are interactable
    public GameObject hideDisplay;
    public GameObject hideText;
    public GameObject leaveDisplay;
    public GameObject leaveText;
    public GameObject theHidingPlace;
    public bool isFlashLightOn;
    
    public GameObject flashlightHidden;
    
    //public GameObject test;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
        mainAudio = player.transform.Find("Character").gameObject.transform.Find("Main Camera").gameObject.GetComponent<AudioListener>();
        mainMusic = player.transform.Find("Character").gameObject.transform.Find("Main Camera").gameObject.GetComponent<AudioSource>();
        //Debug.Log(player.transform.Find("Character").gameObject.transform.Find("Main Camera").gameObject.transform.Find("Flashlight").gameObject);
        flashlight = player.transform.Find("Character").gameObject.transform.Find("Main Camera").gameObject.transform.Find("Flashlight").gameObject;
        //test = player.Find("Character");
        //set the active camera
        mainCamera.enabled = true;
        mainAudio.enabled = true;
        mainMusic.Play();
        hidingCamera.enabled = false;
        hidingAudio.enabled = false;
        hidingMusic.Pause();

    }


    // Update is called once per frame
    void Update()
    {
        //get the active/inactive state of the flashlight
        isFlashLightOn = flashlight.activeInHierarchy;
        //update the discance from the player to the target every interaction
        theDistance = PlayerCasting.DistanceFromTarget;
        //TODO - dont working
        if(isHiding){
            if(Input.GetButtonDown("Action")){
                //Enable player
                //GameObject.Find("PlayerControllerFPS Variant 1").transform.GetChild(0).SetActive(true);                
                player.transform.GetChild(0).gameObject.SetActive(true);

                //Switch cameras
                mainCamera.enabled = true;
                mainAudio.enabled = true;
                mainMusic.Play();
                hidingCamera.enabled = false;
                hidingAudio.enabled = false;
                hidingMusic.Pause();

                isHiding = false;
                justHide = false;
                isHidingWardrobe = false;

                leaveDisplay.SetActive(false);
                leaveText.SetActive(false);
            }
        }else{
            isHiding = justHide;
            Wait();
        }
    }

    //function if the mouse is pointing the door
    void OnMouseOver(){
        if (!isHiding){
            if(theDistance <= 3){
                //guiShow = true;
                //show text and button
                hideDisplay.SetActive(true);
                hideText.SetActive(true);
            
                //get the action key
                if(Input.GetButtonDown("Action")){
                    //Disable player
                    //GameObject.Find("PlayerControllerFPS Variant 1").transform.GetChild(0).SetActive(false);
                    player.transform.GetChild(0).gameObject.SetActive(false);

                    //Switch cameras
                    mainCamera.enabled = false;
                    mainAudio.enabled = false;
                    mainMusic.Pause();
                    hidingCamera.enabled = true;
                    hidingAudio.enabled = true;
                    hidingMusic.Play();
                    //flashlight.SetActive(false);
                    //isFlashLightOn = false;
                    if (isFlashLightOn){
                        flashlightHidden.SetActive(true);
                    }


                    justHide = true;
                    isHidingWardrobe = true;
    
                    hideDisplay.SetActive(false);
                    hideText.SetActive(false);
                    leaveDisplay.SetActive(true);
                    leaveText.SetActive(true);
                    
                    //onInteract.Invoke();
                }
            }else{
                //hide text and button
                hideDisplay.SetActive(false);
                hideText.SetActive(false);
            }
        }
    }
    
    //function if the mouse is not pointing anymore
    void OnMouseExit(){
        //hide text and button
        hideDisplay.SetActive(false);
        hideText.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}