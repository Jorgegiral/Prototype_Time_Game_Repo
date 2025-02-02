using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues_pensatives : MonoBehaviour
{
    public GameObject dialogue;
    public float time;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            StartCoroutine(HideDialogue(time));
        }
    }
    private IEnumerator HideDialogue(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (dialogue != null)
        {
            dialogue.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
