using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private Slider AudioSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("AudioVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetVolume()
    {
        float volume = AudioSlider.value;
        AudioMixer.SetFloat("Audio", MathF.Log10(volume)*20);
        PlayerPrefs.SetFloat("AudioVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        AudioMixer.SetFloat("Music", MathF.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        AudioMixer.SetFloat("SFX", MathF.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void LoadVolume()
    {
        AudioSlider.value = PlayerPrefs.GetFloat("AudioVolume");
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
