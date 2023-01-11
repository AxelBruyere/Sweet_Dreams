using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public static bool haveMonkey = false;
    public static bool haveRabbit = false;
    public static bool haveDinosaur = false;
    public static bool haveAlligator = false;
    public static bool haveElephant = false;


    public Transform ItemContent;
    public GameObject InventoryItem;
    GameObject PlushScene;

    private void Awake()
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

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }
    

   public void ListItems()
    {
        int index = 0;
        //Clean content before open.
        if(ItemContent != null)
        {
            foreach(Transform item in ItemContent)
            {
                if(index != 0)
                {
                    //Debug.Log(item.name);
                    //Destroy(item.gameObject);
                    //item.gameObject.SetActive(false);
                }
                index += 1;
            }
        }
       

        foreach(var item in Items)
        {
            Debug.Log(item);
            /*GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;

            itemName.text = item.transform.Find("ItemName").GetComponent<Text>();
            itemIcon.sprite = item.transform.Find("ItemIcon").GetComponent<Image>();*/
        }
    }   
}
