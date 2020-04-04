using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public SkinnedMeshRenderer mesh;

    public int armorModifire;
    public int damageModifire;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        removeFromInvetory();
    }
}
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet}
