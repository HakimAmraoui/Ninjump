using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private LevelManager levelManager;

    private bool isOn;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        levelManager = GameObject.FindGameObjectWithTag("GameManager").transform.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
            }
        }
    }
}