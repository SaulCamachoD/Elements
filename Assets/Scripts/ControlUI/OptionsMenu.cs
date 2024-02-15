using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using System;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ControlVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void ControlQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
