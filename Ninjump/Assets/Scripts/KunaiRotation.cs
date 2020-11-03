using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiRotation : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        // Mouse Position in world game
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
