using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string[] currentEquipment;
    public string[] inventoryEquipment;

    public PlayerData(EquipmentManager equipmentManager, Inventory inventory)
    {

/*        List<string> eqNames = new List<string>();
        if (equipmentManager.currentEquipment != null)
        {
            foreach (Equipment eq in equipmentManager.currentEquipment)
            {
                eqNames.Add(eq.name);
                Debug.Log(eq.name);
            }
        }*/

        //test 
        string[] a1 = new string[] { "w eq" };


        List<string> itemNames = new List<string>();
        foreach (Equipment item in inventory.items)
        {
            itemNames.Add(item.name);
        }

        currentEquipment = a1;
        inventoryEquipment = itemNames.ToArray();
    }
}












/*        var dictionary = new Dictionary<string, Equipment>()
        {
            {"", "" },
            {"", "" }
        };

        currentEquipment = equipmentManager.currentEquipment;
        inventoryEquipment = inventory.items.ToArray();*/

/*        string[] a1 = new string[] { "w invie" };
string[] a2 = new string[] { "na sobie" };*/
