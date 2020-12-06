using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Death");
            
            // Stop player movement
            PlayerMovements.instance.rb.velocity = new Vector2(0,0);
            
            // Disable all movements
            PlayerMovements.instance.enableMovements = false;
            KunaiRotation.instance.enableRotation = false;
            KunaiThrow.instance.enableThrow = false;
            
            // Active Game Over UI
            GameOverUI.SetActive(true);

        }
    }
}
