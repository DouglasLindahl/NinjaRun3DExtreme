using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{

    float time;
    private float startTime;
    private Text timerText;
    private GameObject player;
    public string publicTimeText;

    void Start()
    {
        player = GameObject.Find("Player Holder");
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        startTime = Time.time;
        time = Time.time - startTime;
    }

    void Update()
    {
        
        if (player.GetComponent<PlayerDeath>().dead == false)
        {
            time = Time.time - startTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);

            string timeText = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            timerText.text = timeText;
        }
    }
}
