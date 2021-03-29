using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    float musicVolume;
    float soundEffectVolume;

    public Scrollbar musicVolumeSlider;
    public Text musicVolumeText;

    public Scrollbar soundEffectVolumeSlider;
    public Text soundEffectVolumeText;

    public AudioSource backgroundTrack;
    public AudioSource jumpSound;
    public AudioSource dashSound;
    public AudioSource deathSound;
    public AudioSource victorySound;
    public AudioSource coinSound;
    public AudioSource explosionSound;

    private void Awake()
    {
        musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Scrollbar>();
        soundEffectVolumeSlider = GameObject.Find("SoundEffectVolumeSlider").GetComponent<Scrollbar>();
        musicVolumeText = GameObject.Find("MusicVolumeText").GetComponent<Text>();
        soundEffectVolumeText = GameObject.Find("SoundEffectVolumeText").GetComponent<Text>();
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        soundEffectVolume = PlayerPrefs.GetFloat("SoundEffectVolume");
    }
    void Start()
    {        
        musicVolumeSlider.value = musicVolume;
        soundEffectVolumeSlider.value = soundEffectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
        musicVolume = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        musicVolumeText.text = (musicVolume * 100).ToString("f0") + "%";
        soundEffectVolume = soundEffectVolumeSlider.value;
        PlayerPrefs.SetFloat("SoundEffectVolume", soundEffectVolume);
        soundEffectVolumeText.text = (soundEffectVolume * 100).ToString("f0") + "%";

        backgroundTrack.volume = musicVolume;
        
        jumpSound.volume = soundEffectVolume;
        dashSound.volume = soundEffectVolume;
        deathSound.volume = soundEffectVolume;
        victorySound.volume = soundEffectVolume;
        coinSound.volume = soundEffectVolume;
        explosionSound.volume = soundEffectVolume;
    }   
}
