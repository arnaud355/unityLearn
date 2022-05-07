using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public Text timeText;
    private GameManagerX gameManagerX;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }
    void Update()
    {
        if (timerIsRunning && gameManagerX.isGameActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                gameManagerX.GameOver();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("Time: " + "{0:00}:{1:00}", minutes, seconds);
    }
}