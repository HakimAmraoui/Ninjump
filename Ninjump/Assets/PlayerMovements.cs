using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private Rigidbody2D rb;
    // [SerializeField] private Camera cam;

    // private Vector2 movement;
    private Vector2 mousePos;
    private Vector2 lookDir;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // When the player left click
        if (Input.GetButtonDown("Fire1"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // By subtracting a vector by another we got a vector that points from one to the other  
        lookDir = mousePos - rb.position;
    }

    void Jump()
    {
        //rb.AddForce(transform.forward * jumpForce, ForceMode2D.Impulse);
        rb.velocity = new Vector2(lookDir.x * jumpForce, lookDir.y * jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
