using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Threading.Tasks;

public class SaveOptions : MonoBehaviour
{
     float musicVolume;
     bool playMusic;
    int danceType;

    public Slider musicSlider;
    public Slider danceSlider;
    public Toggle playMusicToggle;

    public AudioMixer audioMixer;
    public AudioSource audioSource;
    public Animator animator;
    private void Start()
    {
        LoadSettings();
    }
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            musicVolume = PlayerPrefs.GetFloat("Volume");
            musicSlider.value = musicVolume;
        }
        if (PlayerPrefs.HasKey("PlayMusic"))
        {
            playMusic = PlayerPrefs.GetInt("PlayMusic") == 1;
            playMusicToggle.isOn = playMusic;
        }
        if (PlayerPrefs.HasKey("Dance"))
        {
            danceType = PlayerPrefs.GetInt("Dance");
            danceSlider.value = danceType;
        }
    }

    public void OnVolumeChanged()
    {
        musicVolume = musicSlider.value;
        audioMixer.SetFloat("Volume", musicVolume);
        PlayerPrefs.SetFloat("Volume", musicVolume);
    }

    public void OnMusicToggled()
    {
        playMusic = playMusicToggle.isOn;
        audioSource.enabled = playMusic;
        PlayerPrefs.SetInt("PlayMusic", playMusic ? 1 : 0);

    }

    public void OnDanceChanged()
    {
        danceType = (int)danceSlider.value;
        PlayerPrefs.SetInt("Dance", danceType);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Voluyme", musicVolume);
        PlayerPrefs.SetInt("PlayMusic", playMusic ? 1 : 0);
        PlayerPrefs.SetInt("Dance", danceType);
        PlayerPrefs.Save(); 
    }
}
