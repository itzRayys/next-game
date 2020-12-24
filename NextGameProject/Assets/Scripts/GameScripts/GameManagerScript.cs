using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManagerScript : MonoBehaviour
{
    [Header("Player Controller")]
    public PlayerController PC;

    [Header("Other References")]
    public Destructable Dest;
    public DeadorGoal Dog;
    public GameObject levelCompleteUI;
    public LevelCompleteMenuScript LCMS;
    public LevelLoadingScript LLS;
    public GameObject AreaOb;
    public TextMeshProUGUI TipText;

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
        //When level restarts, checks to see if player has beat the level before overwriting
        //  the level to load
        LLS.SetLevelToLoad();
        if (LLS.levelToLoad <= SceneManager.GetActiveScene().buildIndex)
        {
            LLS.levelToLoad = SceneManager.GetActiveScene().buildIndex;
            LLS.SaveLevel();
        }

        AreaOb.GetComponent<TilemapRenderer>().enabled = false;
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
        //Starts time on first move and disables tips text
        if (!isTimerGoing)
        {
            if (Math.Abs(Input.GetAxisRaw("Vertical")) == 1 || Math.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                Timer.StartCoroutine(Timer.Timer1());
                isTimerGoing = true;
                TipText.text = "";
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

        //Checks if player has beat the current level, if not then saves to load the next level
        //  for the next time the player quits and continues
        if (LLS.levelToLoad == SceneManager.GetActiveScene().buildIndex)
        {
            LLS.levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            LLS.SaveLevel();
        }

        LevelCompleteScreen.GetComponent<LevelCompleteScript>().Invoke("levelComplete", 0.1f);
    }
}
