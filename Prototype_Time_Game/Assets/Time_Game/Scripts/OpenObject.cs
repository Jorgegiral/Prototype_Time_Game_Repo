using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    public string requiredItemID;
    public Inventory inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }
    void OpenDoor()
    {
        if (inventory.HasItem(requiredItemID))
        {
            gameObject.SetActive(false);
            inventory.RemoveItem(requiredItemID);
        }
    }
}
