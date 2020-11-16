using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KunaiThrow : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float throwForce = 20f;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && KunaiRotation.instance.isPickedUp)
        {
            Shoot();
            Debug.Log("shoot");
        }
    }

    void Shoot()
    {
        transform.parent = null;
        KunaiRotation.instance.isPickedUp = false;
        rb.AddForce(transform.up * throwForce, ForceMode2D.Impulse);
    }
}