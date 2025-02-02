using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject disableObject;
    public GameObject disableObject2;
    public GameObject activateObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (activateObject != null)
            {
                activateObject.SetActive(true);
            }
            if (disableObject != null)
            {
                disableObject.SetActive(false);
                disableObject2.SetActive(false);
            }
        }
        
    }

}
