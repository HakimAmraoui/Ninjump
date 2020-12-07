using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeStart, timer;
    [SerializeField] private Text textBox;

    [SerializeField] private float gold, silver, bronze;
    [SerializeField] private GameObject goldSprite, silverSprite, bronzeSprite;

    public bool timerActive;
    
    // The instance is use when we use that methode from another script
    public static Timer instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of Timer in the scene.");
            return;
        }
        instance = this;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString("F1");
        timer = 0f;
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            textBox.text = timer.ToString("F1");
        }

        if (timer <= gold)
        {
            goldSprite.SetActive(true);
            silverSprite.SetActive(false);
            bronzeSprite.SetActive(false);
        }
        else if (gold < timer && timer <= silver)
        {
            goldSprite.SetActive(false);
            silverSprite.SetActive(true);
            bronzeSprite.SetActive(false);
        }
        else if (silver < timer && timer <= bronze)
        {
            goldSprite.SetActive(false);
            silverSprite.SetActive(false);
            bronzeSprite.SetActive(true);
        }
    }
}