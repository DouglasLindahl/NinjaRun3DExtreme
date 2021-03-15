using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLevel : MonoBehaviour
{
    [SerializeField]
    Text timeText;
    GameObject sceneManager;
    AudioSource victorySound;
    GameObject wonMenu;

    void Awake()
    {
        timeText = GameObject.Find("WinTime").GetComponent<Text>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        wonMenu = GameObject.Find("LevelWonMenu");
        victorySound = GameObject.Find("VictorySoundFX").GetComponent<AudioSource>();
    }
    void OpenWonMenu()
    {
        wonMenu.SetActive(true);
        timeText.text = sceneManager.GetComponent<Timer>().publicTimeText;
        sceneManager.GetComponent<PauseMenu>().canOpenMenu = false;
        Time.timeScale = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        OpenWonMenu();
        victorySound.Play();
    }
}
