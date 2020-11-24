using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiRotation : MonoBehaviour
{
    public static KunaiRotation instance;

    public  bool isPickedUp = true;
    [SerializeField] private GameObject attachmentPoint;
    public bool enableRotation;

    private Vector2 dir;
    private void Awake()
    {
        // On evite de creer plusieur instance d'Inventory
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scene");
            return;
        }

        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (enableRotation)
        {
            // Mouse Position in world game
            dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        }
        

        if (isPickedUp)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = attachmentPoint.transform.position;
        }
    }
}