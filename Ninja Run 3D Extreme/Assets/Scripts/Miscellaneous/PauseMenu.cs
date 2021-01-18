using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu")]
    bool menuOpen = false;
    bool settingsOpen = false;
    bool levelSelectorOpen = false;
    public GameObject menu;
    public GameObject settings;
    public GameObject levelSelector;


    private void Start()
    {
        menu.SetActive(false);
        menuOpen = false;
    }
    void Update()
    {
        if (menuOpen)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
        OpenRightWindow();
    }
    void OpenRightWindow()
    {
        if(settingsOpen)
        {
            settings.SetActive(true);
        }
        else
        {
            settings.SetActive(false);
        }
        if(levelSelectorOpen)
        {
            levelSelector.SetActive(true);
        }
        else
        {
            levelSelector.SetActive(false);
        }
    }
    public void ResumeGame()
    {
        menu.SetActive(false);
        menuOpen = false;
    }
    public void OpenMenu()
    {
        if (menuOpen)
        {
            menu.SetActive(false);
            menuOpen = false;
            levelSelectorOpen = false;
            settingsOpen = false;
        }
        else
        {
            menu.SetActive(true);
            menuOpen = true;
            settingsOpen = true;
        }
    }
    public void OpenSettings()
    {
        settingsOpen = true;
        levelSelectorOpen = false;
    }
    public void OpenLevelSelector()
    {
        levelSelectorOpen = true;
        settingsOpen = false;
    }
}
