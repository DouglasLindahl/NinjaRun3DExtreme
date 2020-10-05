using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    void Start()
    {
        musicVolumeSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MusicVolume();
        SoundEffectVolume();
    }
    void MusicVolume()
    {
        musicVolume = musicVolumeSlider.value * 100;
        musicVolumeTextValue = Mathf.RoundToInt(musicVolume);
        musicVolumeText.text = musicVolumeTextValue.ToString() + "%";
    }
    void SoundEffectVolume()
    {
        soundEffectVolume = soundEffectVolumeSlider.value * 100;
        soundEffectVolumeTextValue = Mathf.RoundToInt(soundEffectVolume);
        soundEffectVolumeText.text = soundEffectVolumeTextValue.ToString() + "%";
    }
}
