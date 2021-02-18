using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Singleton

    public static InventoryUI instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory fpund!");

            return;
        }

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

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;
    public GameObject[] gameObjectSlots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
/*        gameObjectSlots = itemsParent.GetComponentsInChildren<GameObject>();*/
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateSlots();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].Additem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void UpdateSlots()
    {
        for (int i = 0; i < gameObjectSlots.Length; i++)
        {
            if (i < inventory.space)
                gameObjectSlots[i].SetActive(true);

            else
                gameObjectSlots[i].SetActive(false);
        }
    }
}
