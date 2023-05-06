using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SaveOptions : MonoBehaviour
{
    public float musicVolume;
    public bool playMusic;

    public AudioMixer audioMixer;

    private void Start()
    {

        LoadSettings();
    }
    public void LoadSettings()
    {
        musicVolume = PlayerPrefs.GetFloat("Volume");
        playMusic = PlayerPrefs.GetInt("PlayMusic") == 1;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Voluyme", musicVolume);
        PlayerPrefs.SetInt("PlayMusic", playMusic ? 1 : 0);
        PlayerPrefs.Save(); 
    }
}
