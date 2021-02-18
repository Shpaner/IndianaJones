using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

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

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 4;

    public List<Item> items = new List<Item>();

    public Dialogue dialogue;
    public GameObject dialogueBox; 

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (item.name == "Diary")
            {
                /*FindObjectOfType<DialogueTrigger>().TriggerDialogue(dialogue);*/
                dialogueBox.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                return false;
            }

            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
