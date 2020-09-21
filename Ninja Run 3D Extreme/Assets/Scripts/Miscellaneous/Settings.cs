using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    bool settingsOpen = false;
    public GameObject settings;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenSettings()
    {
        if (settingsOpen)
        {
            settings.SetActive(false);
            settingsOpen = false;
        }
        else
        {
            settings.SetActive(true);
            settingsOpen = true;
        }
    }
}
