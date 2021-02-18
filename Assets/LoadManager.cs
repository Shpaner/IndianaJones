using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    #region singleton
    public static LoadManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public bool shouldLoadPlayer;
    //public Item przykladowyItem;

    public void SetBoolTrue()
    {
        shouldLoadPlayer = true;
    }

    public void SetBoolFalse()
    {
        shouldLoadPlayer = false;
    }
}
