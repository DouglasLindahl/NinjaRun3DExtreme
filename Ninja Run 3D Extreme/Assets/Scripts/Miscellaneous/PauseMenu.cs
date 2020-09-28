using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool menuOpen = false;
    public GameObject menu;

    void Start()
    {

    }

    // Update is called once per frame
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
    }
    public void OpenMenu()
    {
        if (menuOpen)
        {
            menu.SetActive(false);
            menuOpen = false;
        }
        else
        {
            menu.SetActive(true);
            menuOpen = true;
        }
    }
}
