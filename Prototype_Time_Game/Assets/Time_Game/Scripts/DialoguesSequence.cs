using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesSequence : MonoBehaviour
{
    public GameObject dialoguepensative;
    bool dialogueactive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueactive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueactive = false;
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (dialogueactive)
        {
            dialoguepensative.SetActive(true);
        }
    }
}
