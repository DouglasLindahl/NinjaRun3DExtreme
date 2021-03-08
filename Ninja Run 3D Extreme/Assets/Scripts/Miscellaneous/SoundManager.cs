using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    float musicVolume;
    int musicVolumeTextValue;
    public Scrollbar musicVolumeSlider;
    public Text musicVolumeText;

    float soundEffectVolume;
    int soundEffectVolumeTextValue;
    public Scrollbar soundEffectVolumeSlider;
    public Text soundEffectVolumeText;

    public AudioSource backgroundTrack;
    public AudioSource jumpSound;
    public AudioSource dashSound;
    public AudioSource deathSound;
    public AudioSource victorySound;

    GameObject[] mngr;
    private Scene scene;

    private void Awake()
    {
        musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Scrollbar>();
        soundEffectVolumeSlider = GameObject.Find("SoundEffectVolumeSlider").GetComponent<Scrollbar>();
        musicVolumeText = GameObject.Find("MusicVolumeText").GetComponent<Text>();
        soundEffectVolumeText = GameObject.Find("SoundEffectVolumeText").GetComponent<Text>();
    }
    void Start()
    {
        musicVolumeSlider.value = musicVolume;
        soundEffectVolumeSlider.value =  soundEffectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        MusicVolume();
        SoundEffectVolume();
        backgroundTrack.volume = musicVolume;
        jumpSound.volume = soundEffectVolume;
        dashSound.volume = soundEffectVolume;
        deathSound.volume = soundEffectVolume;
        victorySound.volume = soundEffectVolume;
    }
    void MusicVolume()
    {
        musicVolume = musicVolumeSlider.value;
        musicVolumeTextValue = Mathf.RoundToInt(musicVolume * 100);
        musicVolumeText.text = musicVolumeTextValue.ToString() + "%";
    }
    void SoundEffectVolume()
    {
        soundEffectVolume = soundEffectVolumeSlider.value;
        soundEffectVolumeTextValue = Mathf.RoundToInt(soundEffectVolume * 100);
        soundEffectVolumeText.text = soundEffectVolumeTextValue.ToString() + "%";
    }

    void OnSceneWasSwitched()
    {
        musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Scrollbar>();
        soundEffectVolumeSlider = GameObject.Find("SoundEffectVolumeSlider").GetComponent<Scrollbar>();
        musicVolumeText = GameObject.Find("MusicVolumeText").GetComponent<Text>();
        soundEffectVolumeText = GameObject.Find("SoundEffectVolumeText").GetComponent<Text>();
    }
   
}
