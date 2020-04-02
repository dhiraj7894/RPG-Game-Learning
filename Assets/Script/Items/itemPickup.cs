using System;
using UnityEngine;

public class itemPickup : Interactable
{
    public Item item;
    public override void interact()
    {
        base.interact();

        PickUpItem();
    }

    private void PickUpItem()
    {
        Debug.Log("Picking up "+item.name);

        bool wasPickedUp = Inventory.instance.Add(item);
        
        if(wasPickedUp)
            Destroy(gameObject);
    }
}
