using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [Header("Player Controller")]
    public PlayerController PC;

    [Header("Screens")]
    public GameObject LevelCompleteScreen;
    public PauseMenuScript PMS;

    [Header("Timer")]
    public TimerScript Timer;
    public float LevelTime;
    public bool isPausable;
    private string tempTime;
    private bool isTimerGoing = false;


    private void Start()
    {
        isPausable = true;
        PC.playerToStart();
        Time.timeScale = 1f;
        Timer.startTime = LevelTime;
        FormatTime();
        Timer.timerText1.text = tempTime;
    }

    private void Update()
    {
        if (!isTimerGoing)
        {
            if (Math.Abs(Input.GetAxisRaw("Vertical")) == 1 || Math.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                Timer.StartCoroutine(Timer.Timer1());
                isTimerGoing = true;
            }
        }
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    private void FormatTime()
    {
        if (LevelTime > 0)
        {
            int minutes = (int)(LevelTime / 60) % 60;
            float seconds = (float)(LevelTime % 60);

            tempTime = "";
            if (minutes > 0 && minutes < 10) { tempTime += string.Format("{0:0}:", minutes); }
            else if (minutes > 0) { tempTime += string.Format("{0:00}:", minutes); }
            if (seconds > 0 && seconds < 10) { tempTime += string.Format("{0:0.00}", seconds); }
            else { tempTime += string.Format("{0:00.00}", seconds); }
        }
        else { tempTime = "0.00"; }
    }
}
