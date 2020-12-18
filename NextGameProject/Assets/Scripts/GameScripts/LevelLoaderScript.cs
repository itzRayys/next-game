using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelLoaderScript : MonoBehaviour
{

    private string currentLevel;
    private int levelNumber;
    public GameObject nextLevelGO;
    public GameObject prevLevelGO;
    public GameManagerScript GMS;
    public PlayerController PC;

    private Vector3 nextLevelStartCoord;
    private Vector3 nextLevelEndCoord;
    private float nextLevelTimerValue;

    [Header("Start Coordinates")]
    public StartCoordsClass[] StartCoords;

    [Header("End Coordinates")]
    public EndCoordsClass[] EndCoords;

    [Header("Timer")]
    public TimerClass[] TimerValue;
    private IEnumerator TimerStart;

    private bool isTimerGoing;
    private string tempTime;

    private void Start()
    {
        TimerStart = GMS.Timer.Timer1();
        currentLevel = "Tilemap_Level_1";
        LoadLevel();
    }

    private void LateUpdate()
    {
        if (!isTimerGoing)
        {
            if (Math.Abs(Input.GetAxisRaw("Vertical")) == 1 || Math.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                StartTime();
                isTimerGoing = true;
            }
        }
    }

    public void LoadLevel()
    {
        if (currentLevel.Length == 15)
        {
            levelNumber = Convert.ToInt32(currentLevel.Substring(currentLevel.Length - 1));
        }
        else if (currentLevel.Length == 16)
        {
            levelNumber = Convert.ToInt32(currentLevel.Substring(currentLevel.Length - 2));
        }

        currentLevel = GMS.Levels[levelNumber - 1].GameObject.ToString();
        prevLevelGO = GMS.Levels[levelNumber - 1].GameObject;
        prevLevelGO.SetActive(false);

        nextLevelGO = GMS.Levels[levelNumber].GameObject;
        nextLevelGO.SetActive(true);

        nextLevelStartCoord = StartCoords[levelNumber].coords;
        GMS.startPoint.transform.position = nextLevelStartCoord;

        nextLevelEndCoord = EndCoords[levelNumber].coords;
        GMS.Goal.transform.position = nextLevelEndCoord;

        PC.playerToStart();

        nextLevelTimerValue = TimerValue[levelNumber].timer;
        GMS.Timer.startTime = nextLevelTimerValue;
        FormatText();
        GMS.Timer.timerText1.text = tempTime;
    }

    public void StartTime()
    {
        GMS.Timer.StartCoroutine(TimerStart);
    }

    private void FormatText()
    {
        if (nextLevelTimerValue > 0)
        {
            int minutes = (int)(nextLevelTimerValue / 60) % 60;
            float seconds = (float)(nextLevelTimerValue % 60);

            tempTime = "";
            if (minutes > 0 && minutes < 10) { tempTime += string.Format("{0:0}:", minutes); }
            else if (minutes > 0) { tempTime += string.Format("{0:00}:", minutes); }
            if (seconds > 0 && seconds < 10) { tempTime += string.Format("{0:0.00}", seconds); }
            else { tempTime += string.Format("{0:00.00}", seconds); }
        }
        else { tempTime = "0.00"; }
    }
}
