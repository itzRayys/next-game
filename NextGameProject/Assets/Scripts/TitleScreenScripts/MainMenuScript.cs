using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Loads first level
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Play Game");
    }

    //Quits game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
