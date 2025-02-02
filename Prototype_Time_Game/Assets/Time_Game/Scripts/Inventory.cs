using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    List<string> itemsID = new List<string>();
    public GameObject[] inventory;
    public GameObject items;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            items = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") && collision.gameObject == items)
        {
            items = null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && items != null)
        {
            TakeItems(items);
        }
    }

    private void TakeItems(GameObject item)
    {
        string itemID = item.GetComponent<Item>().itemID;
        for (int i = 0; i < slots.Count; i++)
        {
            Image slotImage = slots[i].GetComponent<Image>();
            if (slotImage.enabled == false)
            {
                slotImage.enabled = true;
                slotImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
                itemsID.Add(itemID);
                item.SetActive(false);
                items = null;
                break;
            }
        }
    }
    public bool HasItem(string itemID)
    {
        return itemsID.Contains(itemID);
    }
    public void RemoveItem(string itemID)
    {
        if (itemsID.Contains(itemID))
        {
            itemsID.Remove(itemID);

            for (int i = 0; i < slots.Count; i++)
            {
                Image slotImage = slots[i].GetComponent<Image>();
                if (slotImage != null && slotImage.enabled && slotImage.sprite.name == itemID)
                {
                    slotImage.enabled = false;
                    slotImage.sprite = null;
                    break;
                }
            }
        }
    }
}