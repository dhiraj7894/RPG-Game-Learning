﻿using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item") ]
public class Item : ScriptableObject
{

    new public string name= "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public static Item item;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
    public void removeFromInvetory()
    {
        Inventory.instance.onRemove(this);
    }
}
