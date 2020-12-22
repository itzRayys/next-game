using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [Header("Player Controller")]
    public PlayerController PC;

    [Header("Other References")]
    public Destructable Dest;
    public DeadorGoal Dog;
    public GameObject levelCompleteUI;
    public LevelCompleteMenuScript LCMS;

    [Header("Screens")]
    public GameObject LevelCompleteScreen;
    public PauseMenuScript PMS;

    [Header("Timer")]
    public TimerScript Timer;
    public float LevelTime;
    public bool isPausable;
    private string tempTime;
    private bool isTimerGoing = false;

    public int blocksBefore;
    public int blocksAfter;

    public bool timeUp = false;

    //Sets up the level (Counts starting amount of blocks, moves player to start, sets timer time and some other stuff)
    private void Start()
    {
        blocksBefore = Dest.countBlocks(blocksBefore);
        Debug.Log(blocksBefore);
        isPausable = true;
        PC.playerToStart();
        Time.timeScale = 1f;
        Timer.startTime = LevelTime;
        FormatTime();
        Timer.timerText1.text = tempTime;
    }

    private void Update()
    {
        //Starts time on first move
        if (!isTimerGoing)
        {
            if (Math.Abs(Input.GetAxisRaw("Vertical")) == 1 || Math.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                Timer.StartCoroutine(Timer.Timer1());
                isTimerGoing = true;
            }
        }
        
        //Detects when time is up
        if (isTimerGoing && !timeUp && Timer.timer <= 0) 
        { 
            Debug.Log("Times up");
            timeUp = true; 
        }

        //Quick restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    //Loads next level
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    //Restart level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    //Quits to main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1f;
    }

    //Formats temporary time before timer starts
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

    //What to do when goal is reached (Stops time, sets up end screen, some other stuff)
    public void reachedGoal()
    {
        Timer.StopAllCoroutines();
        LCMS.SetTimeLeftText();
        LCMS.SetTilesLeftText();
        Time.timeScale = 0f;
        levelCompleteUI.SetActive(true);
        isPausable = false;
        Debug.Log("Player has reached the goal!");
        Debug.Log(Dest.countBlocks(blocksAfter));
        LevelCompleteScreen.GetComponent<LevelCompleteScript>().Invoke("levelComplete", 0.1f);
    }
}
