using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelLoaderScript : MonoBehaviour
{

    private string currentLevel;
    private string nextLevel;
    private int levelNumber;
    public GameObject nextLevelGO;
    public GameObject prevLevelGO;
    public GameManagerScript GMS;

    private Vector3 nextLevelStartCoord;
    private Vector3 nextLevelEndCoord;


    [Header("Start Coordinates")]
    public StartCoordsClass[] StartCoords;

    [Header("End Coordinates")]
    public EndCoordsClass[] EndCoords;




    private void Start()
    {
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

        nextLevel = GMS.Levels[levelNumber].GameObject.ToString();
        nextLevelGO = GMS.Levels[levelNumber].GameObject;
        nextLevelGO.SetActive(true);

        nextLevelStartCoord = StartCoords[levelNumber].coords;
        GMS.startPoint.transform.position = nextLevelStartCoord;

        nextLevelEndCoord = EndCoords[levelNumber].coords;
        GMS.Goal.transform.position = nextLevelEndCoord;
    }
}
