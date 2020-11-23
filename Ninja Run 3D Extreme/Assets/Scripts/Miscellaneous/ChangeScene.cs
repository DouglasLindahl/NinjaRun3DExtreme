using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
