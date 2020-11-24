using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public GameObject[] lanterns;
    public int counterLanternsOn;

    [SerializeField] private Canvas canvas;
    [SerializeField] private string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        // We fill the array with all the lanterns currently in the level
        lanterns = GameObject.FindGameObjectsWithTag("Lantern");
        
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
}
