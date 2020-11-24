using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] private AudioClip[] playlist;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixerGroup soundEffectMixer;

    private int musicIndex = 0;
    
    
    // The instance is use when we use that methode from another script
    public static AudioManager instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of AudioManager in the scene.");
            return;
        }
        instance = this;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[Random.Range(0, 3)];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // If the song is ended then we play the next
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    private void PlayNextSong()
    {
        // We go to the next song if there is one, otherwise we go back to the begining
        //musicIndex = (musicIndex + 1) % playlist.Length;
        
        // Random playlist
        musicIndex = Random.Range(0, 3);
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
    
    // We can handle the audioSource without it getting destroy
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        // We create a temporary object
        GameObject tempGO = new GameObject("TempAudio");
        // We put this object to the position of the parametre
        tempGO.transform.position = pos;
        
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO,clip.length);
        return audioSource;
    }
}