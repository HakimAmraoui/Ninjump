using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public GameObject[] lanterns;
    public int counterLanternsOn, counterLanters;

    [SerializeField] private GameObject canvas;
    [SerializeField] private string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        // canvas = GameObject.FindWithTag("Canvas");
        
        // Reset counter
        Array.Clear(lanterns, 0, lanterns.Length);
        counterLanters = 0;
        counterLanternsOn = 0;
        
        
        // We fill the array with all the lanterns currently in the level
        lanterns = GameObject.FindGameObjectsWithTag("Lantern");
        counterLanters = lanterns.Length;
        
        // Enable player's movements, throw and rotation
        PlayerMovements.instance.enableMovements = true;
        KunaiRotation.instance.enableRotation = true;
        KunaiThrow.instance.enableThrow = true;
    }

    // Load the next level
    public void LoadStageComplitedUI()
    {
        canvas.gameObject.SetActive(true);
    }

    public void LoadSpecificStage()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void TryAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log(scene.name);
    }
}
