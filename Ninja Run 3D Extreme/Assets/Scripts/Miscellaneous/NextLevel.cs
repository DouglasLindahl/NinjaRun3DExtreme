using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    AudioSource victorySound;

    private void Awake()
    {
        victorySound = GameObject.Find("VictorySoundFX").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        victorySound.Play();
    }
}
