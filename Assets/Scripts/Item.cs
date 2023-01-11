using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName="New Item",menuName="Item/Create New Item")]

public class Item : ScriptableObject
{
    //public int id;
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;

    public Item GetItem() {return this;}
}
