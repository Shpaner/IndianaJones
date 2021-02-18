using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public EquipmentManager equipmentManager;
    public Inventory inventory;

    public Equipment[] allItems;

    public Item przykladowyItem;
    /*    public Item przykladowyItem;
        public Equipment przykladowyNaSobie;*/

    private void Start()
    {
        //save system - load player
        //inventory.Add(przykladowyItem);

        if (LoadManager.instance.shouldLoadPlayer)
        {
            Debug.Log("loadinnnnnn");
            foreach(Equipment eq in LoadPlayer())
            {
                inventory.Add(eq);
            }
            //inventory.Add(przykladowyItem);
            // maybe add all to backpack (including eq on)
        }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(equipmentManager, inventory);
    }

    public Equipment[] LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        List<Equipment> eq = new List<Equipment>();
        foreach (string name in data.inventoryEquipment)
        {
            foreach (Equipment item in allItems)
            {
                if (name == item.name)
                {
                    eq.Add(item);
                }
            }
        }

        return eq.ToArray();

        /*        Equipment[] a1 = new Equipment[] { allItems[0]};
                return a1;*/
    }
}























/*PlayerData data = SaveSystem.LoadPlayer();

Debug.Log(data.currentEquipment[0]);
Debug.Log(data.inventoryEquipment[0]);

//usunac wszystko z invenotory
// dodac to co zapisane

SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

Inventory inventory = Inventory.instance;

foreach (Item item in inventory.items)
{
    inventory.Remove(item);
}

foreach (Item item in inventory.items)
{
    Debug.Log(item.name);
}

inventory.Add(przykladowyItem);

foreach (Item item in inventory.items)
{
    Debug.Log(item.name);
}*/

/*        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(null, oldItem);
        }*/

/*inventory.onItemChangedCallback.Invoke();*/
//UPDATE UI


/*        equipmentManager.currentEquipment = data.currentEquipment;
        inventory.items = data.inventoryEquipment.ToList();*/
