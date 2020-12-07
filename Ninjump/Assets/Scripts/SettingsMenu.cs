using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private float startVolume;

    [SerializeField] private Slider volumeSlider;

    private Resolution[] _resolutions;
    [SerializeField] private Dropdown resolutionDropdown;

    private void Start()
    {
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = _resolutions.Length - 1;
        resolutionDropdown.RefreshShownValue();

        AudioMixer.SetFloat("Volume", startVolume);
        volumeSlider.value = startVolume;
    }

    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}