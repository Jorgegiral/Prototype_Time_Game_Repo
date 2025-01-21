using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testinventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    public GameObject[] inventory;
    public GameObject items;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            items = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") && collision.gameObject == items)
        {
            items = null;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && items != null)
        {
            CollectItem(items);
        }
    }

    private void CollectItem(GameObject item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetComponent<Image>().enabled == false)
            {
                slots[i].GetComponent<Image>().enabled = true;
                slots[i].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                Destroy(item);
                items = null;
                break;
            }
        }
    }
}
