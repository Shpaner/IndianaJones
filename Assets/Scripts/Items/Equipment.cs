using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public SkinnedMeshRenderer mesh;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}


public enum EquipmentSlot { Head, Weapon, MeeleWeapon, Whip, Backpack, Gun, Pouch, DiaryPage1, DiaryPage2, DiaryPage3, DiaryPage4, DiaryPage5 }