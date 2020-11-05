using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] lanterns;
    public int counterLanternsOn;
    
    // Start is called before the first frame update
    void Start()
    {
        // We fill the array with all the lanterns currently in the level
        lanterns = GameObject.FindGameObjectsWithTag("Lantern");
    }

    // Update is called once per frame
    void Update()
    {
        // If all the lanterns are on
        if (counterLanternsOn == lanterns.Length)
        {
            Debug.Log("Level completed");
            // Load net level
            
        }
    }
}
