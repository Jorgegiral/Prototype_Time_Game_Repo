using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTrigger : MonoBehaviour
{
    public Cinematics cinematics;
    public bool isMiddle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isMiddle)
            {
                cinematics.MiddleCinematic();
                gameObject.SetActive(false); 
            }
            else
            {
                cinematics.EndCinematics();
            }

        }
    }
}
