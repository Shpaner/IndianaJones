using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject diaryPage;
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            diaryPage.SetActive(true);
        }
        else
        {
            PlayerManager.instance.SavePlayer();
            //SaveSystem.SavePlayer(EquipmentManager.instance, Inventory.instance);
            LoadManager.instance.SetBoolTrue();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
