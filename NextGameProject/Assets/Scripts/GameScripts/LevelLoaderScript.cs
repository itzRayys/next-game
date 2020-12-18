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


    private void Start()
    {
        TimerStart = GMS.Timer.Timer1();
        currentLevel = "Tilemap_Level_1";
        LoadLevel();
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
        GMS.Timer.StartCoroutine(TimerStart);
    }
}
