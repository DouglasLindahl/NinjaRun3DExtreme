using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu")]
    public bool canOpenMenu;
    public bool menuOpen = false;
    bool settingsOpen = false;
    bool levelSelectorOpen = false;
    public GameObject wonMenu;
    public GameObject menu;
    public GameObject settings;
    public GameObject levelSelector;


    private void Start()
    {
        canOpenMenu = true;
        wonMenu.SetActive(false);
        menu.SetActive(false);
        menuOpen = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canOpenMenu)
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
        Time.timeScale = 1;
    }
    public void OpenMenu()
    {
        if (menuOpen)
        {
            menu.SetActive(false);
            menuOpen = false;
            levelSelectorOpen = false;
            settingsOpen = false;
            Time.timeScale = 1;
        }
        else
        {
            menu.SetActive(true);
            menuOpen = true;
            settingsOpen = true;
            Time.timeScale = 0;
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
