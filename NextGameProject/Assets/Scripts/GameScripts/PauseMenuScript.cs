using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameManagerScript GMS;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && GMS.isPausable)
        {
            if (isPaused) { unpauseGame(); }
            else { pauseGame(); }
        }
    }

    public void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void unpauseGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
