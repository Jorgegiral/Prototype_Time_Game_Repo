using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseObject : MonoBehaviour
{
    public string requiredItemID;
    public Inventory inventory;
    bool close = false;
    Collider2D doorcollider;
    SpriteRenderer doorsprite;

    private void Start()
    {
        doorsprite = GetComponent<SpriteRenderer>();
        doorcollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            close = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            close = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && close)
        {
            ObjectClose();
        }
    }
    void ObjectClose()
    {
        if (inventory.HasItem(requiredItemID))
        {
            doorcollider.enabled = true;
            doorsprite.enabled = true;
            inventory.RemoveItem(requiredItemID);
        }
    }
}
