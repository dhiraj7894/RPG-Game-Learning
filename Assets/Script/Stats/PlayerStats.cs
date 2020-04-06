using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharecterStats
{
    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

    }

    private void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
       if(newItem != null)
        {
            armor.AddModifire(newItem.armorModifire);
            damage.AddModifire(newItem.damageModifire);
        }

       if(oldItem != null)
        {
            armor.RemoveModifire(oldItem.armorModifire);
            damage.RemoveModifire(oldItem.damageModifire);
        }
    }
    public override void Die()
    {
        base.Die();
        PlayerManager.instence.KillPlayer();
    }
}
