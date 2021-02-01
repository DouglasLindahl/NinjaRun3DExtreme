using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float startTime;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player Holder");
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        startTime = Time.time;
    }

    void Update()
    {
        if(player.GetComponent<PlayerDeath>().dead == false)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = ((t % 60)).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
    }
}
