using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowKunai : MonoBehaviour
{
    [SerializeField] private GameObject kunai;

    private Rigidbody2D rb;
    private float throwForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = kunai.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        rb.AddForce(transform.up * throwForce, ForceMode2D.Impulse);
    }
}