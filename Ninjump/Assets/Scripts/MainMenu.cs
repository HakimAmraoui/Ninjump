using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private Image guide;
    [SerializeField] private Button nextButton, endButton;
    [SerializeField] private Text[] texts;
    [SerializeField] private GameObject settings;


    public void PlayGame()
    {
        // We load the first level when we hit the play button
        SceneManager.LoadScene("Scene01");
    }

    public void Option()
    {
        settings.SetActive(true);
    }

    public void BackButton()
    {
        settings.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    
    /////////// How To Play ///////////

    private int currentText = 0;
    
    public void StartGuide()
    {
        guide.gameObject.SetActive(true);
        Continue();

    }

    private void Update()
    {
        if (currentText == texts.Length)
        {
            nextButton.gameObject.SetActive(false);
            endButton.gameObject.SetActive(true);
        } 
    }


    public void Continue()
    {
        if (currentText < texts.Length)
        {
            texts[currentText].gameObject.SetActive(true);
            currentText++;
        }
        else Debug.Log("Fin");
    }
    
}