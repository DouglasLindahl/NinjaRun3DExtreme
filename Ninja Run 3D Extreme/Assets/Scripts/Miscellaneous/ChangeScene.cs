using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ChooseLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void ChooseLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void ChooseLevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void ChooseLevelFour()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
