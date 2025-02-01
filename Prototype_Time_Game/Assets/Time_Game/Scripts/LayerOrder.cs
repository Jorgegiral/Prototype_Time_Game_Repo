using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrder : MonoBehaviour
{
    public int layer;
    SpriteRenderer playerSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerSprite = other.GetComponent<SpriteRenderer>();
            playerSprite.sortingOrder = layer;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerSprite.sortingOrder = 0;
        }
    }
}
