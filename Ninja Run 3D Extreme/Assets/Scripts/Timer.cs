using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float startTime;
    void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((t % 60)).ToString();

        timerText.text = minutes + seconds;
    }
}
