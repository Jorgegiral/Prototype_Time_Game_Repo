using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject enemy;
    public GameObject trigger;
    private GameObject npc;

    void Start()
    {
        npc = GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.SetActive(true);
        }
    }
}
