using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string minutes;
    public string seconds;
    public float time;
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
            time = Time.time - startTime;

            minutes = ((int)time / 60).ToString();
            seconds = ((time % 60)).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
    }
}
