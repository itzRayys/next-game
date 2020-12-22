using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScript : MonoBehaviour
{
    public GameObject levelCompleteUI;

    public void levelComplete()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
