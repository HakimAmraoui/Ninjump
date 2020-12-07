using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public GameObject[] lanterns;
    public int counterLanternsOn, counterLanters;

    [SerializeField] private GameObject canvas, pauseUI;

    [SerializeField] private static bool GameIsPaused;

    
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
        if (PlayerMovements.instance != null)
        {
            PlayerMovements.instance.enableMovements = true;
        }

        if (KunaiRotation.instance != null)
        {
            KunaiRotation.instance.enableRotation = true;
        }
        
        if (KunaiThrow.instance != null)
        {
            KunaiThrow.instance.enableThrow = true;
        }

        GameIsPaused = false;


    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    
    public void Resume()
    {
        // Block player's movements, throw and rotation
        PlayerMovements.instance.enableMovements = true;
        KunaiRotation.instance.enableRotation = true;
        KunaiThrow.instance.enableThrow = true;
        
        pauseUI.gameObject.SetActive(false);
        
        Timer.instance.timerActive = true;
        GameIsPaused = false;
    }

    void Pause()
    {
        // Block player's movements, throw and rotation
        PlayerMovements.instance.enableMovements = false;
        KunaiRotation.instance.enableRotation = false;
        KunaiThrow.instance.enableThrow = false;
        
        pauseUI.gameObject.SetActive(true);
        Timer.instance.timerActive = false;
        GameIsPaused = true;
    }
    

    // Load the next level
    public void LoadStageComplitedUI()
    {
        canvas.gameObject.SetActive(true);
        Timer.instance.timerActive = false;
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

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
}