using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private GameObject slotHolder;
    public List<Item> Items = new List<Item>();

    public static bool haveMonkey = false;
    public static bool haveRabbit = false;
    public static bool haveDinosaur = false;
    public static bool haveAlligator = false;
    public static bool haveElephant = false;

    [SerializeField] private Item itemToAdd;

    private GameObject[] slots;

    /*public Transform ItemContent;
    public GameObject InventoryItem;*/
    private GameObject PlushScene;

    public void Awake()
    {
        Instance = this;
        PlushScene = GameObject.FindWithTag("Plush");
        //Debug.Log(PlushScene);

        if(PlushScene != null){
            if (haveDinosaur && PlushScene.name == "Dinossaur"){

                //Debug.Log("ca marche");
                PlushScene.SetActive(false);
            }
            if (haveRabbit && PlushScene.name == "Rabbit"){

                //Debug.Log("ca marche");
                PlushScene.SetActive(false);
            }
            if (haveElephant && PlushScene.name == "Elephant"){

                //Debug.Log("ca marche");
                PlushScene.SetActive(false);
            }

            if (haveAlligator && PlushScene.name == "Alligator"){

                //Debug.Log("ca marche");
                PlushScene.SetActive(false);
            }

            if (haveMonkey && PlushScene.name == "Monkey"){

                //Debug.Log("ca marche");
                PlushScene.SetActive(false);
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

    public void RefreshUI(){
        for(int i = 0; i<slots.Length; i++)
        {
            Debug.Log(slots[i]);
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = Items[i].itemIcon;
                slots[i].transform.GetChild(0).GetComponent<Text>().text = Items[i].itemName;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).GetComponent<Text>().text = "";

            }
        }
    }

    public void Add(Item item)
    {
        //Debug.Log(item);
        Items.Add(item);
        RefreshUI();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        RefreshUI();
    }
    

   /*public void ListItems()
    {
        
       /* //Clean content before open.
        if(ItemContent != null)
        {
            foreach(Transform item in ItemContent)
            {    
                //Debug.Log(item.name);
                Destroy(item.gameObject);
                //item.gameObject.SetActive(false);
            
                
            }
        }
       
      

        foreach(var item in Items)
        {
            Debug.Log(item);
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
    }  */
}
