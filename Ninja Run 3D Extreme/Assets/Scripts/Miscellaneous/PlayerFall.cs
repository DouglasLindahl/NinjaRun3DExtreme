using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    public GameObject deathMenu;
    public float deathMenuTimer;
    public bool shouldStartTimer;

    private void Update()
    {
        if(shouldStartTimer)
        {
            if (deathMenuTimer < 0)
            {
                deathMenu.SetActive(true);
            }
            else
            {
                deathMenuTimer -= Time.deltaTime;
            }
        }
    }
}
