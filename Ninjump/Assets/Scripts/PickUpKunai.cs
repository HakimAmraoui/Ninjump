using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKunai : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")  && !KunaiRotation.instance.isPickedUp)
        {
            Debug.Log("Picked up");
            KunaiRotation.instance.isPickedUp = true;
        }
    }
}
