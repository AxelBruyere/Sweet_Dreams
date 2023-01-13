using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private Item itemToAdd;
    public List<Item> Items = new List<Item>();
    private GameObject[] slots;
    public GameObject PlushScene;
    public static InventoryManager Instance;
    public static bool haveMonkey = false;
    public static bool haveRabbit = false;
    public static bool haveDinosaur = false;
    public static bool haveAlligator = false;
    public static bool haveElephant = false;

    public void Awake()
    {
        Instance = this;

        if(PlushScene != null){
            if (haveDinosaur && PlushScene.name == "Dinossaur")
            {
                foreach (Transform child in PlushScene.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            if (haveRabbit && PlushScene.name == "Rabbit")
            {
                foreach (Transform child in PlushScene.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            if (haveElephant && PlushScene.name == "Elephant")
            {
                foreach (Transform child in PlushScene.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            if (haveAlligator && PlushScene.name == "Alligator")
            {
                Debug.Log("ALLIGATORSINVENTORYMANAGER");
                foreach (Transform child in PlushScene.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            if (haveMonkey && PlushScene.name == "Monkey")
            {
                PlushScene.transform.GetComponent<MeshRenderer>().enabled=false;
            }
        }
    }

    private void Start(){
        slots = new GameObject[slotHolder.transform.childCount];
        //set all the slots
        for(int i = 0; i<slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();

        Add(itemToAdd);
    }

    private void Update()
    {
        PlushScene = GameObject.FindWithTag("Plush");
    }

    public void RefreshUI(){
        for(int i = 0; i<slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = Items[i].itemIcon;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = Items[i].itemName;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = " ";

            }
        }
    }

    public void Add(Item item)
    {
        Items.Add(item);
        RefreshUI();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        RefreshUI();
    }
}
