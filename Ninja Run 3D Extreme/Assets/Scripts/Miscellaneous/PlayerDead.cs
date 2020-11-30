using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    public GameObject deathMenu;
    public float deathTimer;

    void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(deathTimer <= 0)
            {
                deathMenu.SetActive(true);
            }
            else
            {
                deathTimer -= Time.deltaTime;
            }
        }
    }
}
