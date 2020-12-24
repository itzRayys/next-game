using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Loads first level
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("LevelToLoad") > 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelToLoad"));
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        Debug.Log("Play Game");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("LevelToLoad", 1);
        SceneManager.LoadScene(1);
    }

    //Quits game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
