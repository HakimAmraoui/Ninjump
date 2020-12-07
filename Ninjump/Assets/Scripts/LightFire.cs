using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private AudioClip fireMatch;

    private bool isOn;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        levelManager = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<LevelManager>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOn)
        {
            if (collision.CompareTag("Player"))
            {
                animator.SetTrigger("Fire_On");
                levelManager.counterLanternsOn++;
                isOn = true;
                AudioManager.instance.PlayClipAt(fireMatch,transform.position);
                
                // If all the lanterns are on
                if (levelManager.counterLanternsOn == levelManager.lanterns.Length)
                {
                    Debug.Log("Level completed");
                    // Load net level

                    // Block player's movements, throw and rotation
                    PlayerMovements.instance.rb.velocity = new Vector2(0, 0);
                    PlayerMovements.instance.enableMovements = false;
                    KunaiRotation.instance.enableRotation = false;
                    KunaiThrow.instance.enableThrow = false;
                    
                    levelManager.LoadStageComplitedUI();

                }
            }
        }
    }
}