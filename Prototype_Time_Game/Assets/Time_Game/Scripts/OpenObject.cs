using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;

public class OpenObject : MonoBehaviour
{
    public string requiredItemID;
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }
    //void Update()
    //{
    //if (Input.GetKeyDown(KeyCode.E) )
    //{
    //OpenDoor();
    //       }
    void OpenDoor()
    {
        if (inventory.HasItem(requiredItemID))
        {
            gameObject.SetActive(false);
        }
    }
}
