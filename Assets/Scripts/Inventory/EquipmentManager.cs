using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
        /*        if (instance == null)
                    instance = this;
                else
                {
                    Destroy(gameObject);
                    return;
                }

                DontDestroyOnLoad(gameObject);*/
    }

    #endregion

    // Roots for new items
    public Transform Backpack_root;
    public Transform Whip_root;
    public Transform Knife_root;
    public Transform Gun_root;
    public Transform Pouch_root;

    public SkinnedMeshRenderer targetMesh;
    public Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    int slotIndex;

    public GameObject DiaryPage1;
    public GameObject DiaryPage2;
    public GameObject DiaryPage3;
    public GameObject DiaryPage4;
    public GameObject DiaryPage5;
    
    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        slotIndex = (int)newItem.equipmentSlot;

        Equipment oldItem = Unequip(slotIndex);


        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, null);
        }

        currentEquipment[slotIndex] = newItem;

        if (newItem != null && newItem.equipmentSlot == EquipmentSlot.DiaryPage1)
        {
            DiaryPage1.SetActive(true);
            return;
        }

        if (newItem != null && newItem.equipmentSlot == EquipmentSlot.DiaryPage2)
        {
            DiaryPage2.SetActive(true);
            return;
        }

        if (newItem != null && newItem.equipmentSlot == EquipmentSlot.DiaryPage3)
        {
            DiaryPage3.SetActive(true);
            return;
        }

        if (newItem != null && newItem.equipmentSlot == EquipmentSlot.DiaryPage4)
        {
            DiaryPage4.SetActive(true);
            return;
        }

        if (newItem != null && newItem.equipmentSlot == EquipmentSlot.DiaryPage5)
        {
            DiaryPage5.SetActive(true);
            return;
        }

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        currentMeshes[slotIndex] = newMesh;

        if (newItem != null && newItem.equipmentSlot == EquipmentSlot.Backpack)
        {
            newMesh.rootBone = Backpack_root;
            inventory.space += 12;
            InventoryUI.instance.UpdateSlots();
        }

        else if (newItem != null && newItem.equipmentSlot == EquipmentSlot.Whip)
        {
            newMesh.rootBone = Whip_root;
        }

        else if (newItem != null && newItem.equipmentSlot == EquipmentSlot.MeeleWeapon)
        {
            newMesh.rootBone = Knife_root;
        }

        else if (newItem != null && newItem.equipmentSlot == EquipmentSlot.Gun)
        {
            newMesh.rootBone = Gun_root;
        }

        else if (newItem != null && newItem.equipmentSlot == EquipmentSlot.Pouch)
        {
            newMesh.rootBone = Pouch_root;
            inventory.space += 4;
            InventoryUI.instance.UpdateSlots();
        }

        else
        {
            newMesh.transform.parent = targetMesh.transform;
            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
        }
    }

    public Equipment Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {

            if (currentEquipment[slotIndex].equipmentSlot == EquipmentSlot.DiaryPage1)
            {
                DiaryPage1.SetActive(false);
            }

            if (currentEquipment[slotIndex].equipmentSlot == EquipmentSlot.DiaryPage2)
            {
                DiaryPage2.SetActive(false);
            }

            if (currentEquipment[slotIndex].equipmentSlot == EquipmentSlot.DiaryPage3)
            {
                DiaryPage3.SetActive(false);
            }

            if (currentEquipment[slotIndex].equipmentSlot == EquipmentSlot.DiaryPage4)
            {
                DiaryPage4.SetActive(false);
            }

            if (currentEquipment[slotIndex].equipmentSlot == EquipmentSlot.DiaryPage5)
            {
                DiaryPage5.SetActive(false);
            }

            if (currentEquipment[slotIndex].equipmentSlot == EquipmentSlot.Pouch)
            {
                inventory.space -= 4;
                InventoryUI.instance.UpdateSlots();
            }

            if (currentEquipment[slotIndex].equipmentSlot == EquipmentSlot.Backpack)
            {
                inventory.space -= 12;
                InventoryUI.instance.UpdateSlots();
            }

            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            return oldItem;
        }

        return null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(slotIndex);
            Unequip(slotIndex);
        }
    }

    //spawn item on ground on unequip
}





/*    public void Equip(Equipment newItem)
    {
        slotIndex = (int)newItem.equipmentSlot;

        // check if current mesh slot is not empty
        if (currentMeshes[slotIndex] != null)
        {
            // switch meshes
            Unequip(slotIndex);
        }

        Equipment oldItem = null;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        // everything except head, because its attached differently
        if (slotIndex != 0)
        {
            //Debug.Log(newMesh.transform.localScale);
            //scale
        }

        currentMeshes[slotIndex] = newMesh;
    }*/
