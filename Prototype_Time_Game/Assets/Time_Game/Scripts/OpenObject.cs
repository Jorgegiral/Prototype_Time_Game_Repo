using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    public string requiredItemID;
    public Inventory inventory;
    bool open = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            open = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            open = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && open)
        {
            ObjectOpen();
        }
    }
    void ObjectOpen()
    {
        if (inventory.HasItem(requiredItemID))
        {
            gameObject.SetActive(false);
            inventory.RemoveItem(requiredItemID);
        }
    }
}
