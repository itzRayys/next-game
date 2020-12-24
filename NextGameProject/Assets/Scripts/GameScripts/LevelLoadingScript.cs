using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadingScript : MonoBehaviour
{
    public int levelToLoad;

    public void SaveLevel()
    {
        PlayerPrefs.SetInt("LevelToLoad", levelToLoad);
    }

    public void SetLevelToLoad()
    {
        levelToLoad = PlayerPrefs.GetInt("LevelToLoad");
    }
}
