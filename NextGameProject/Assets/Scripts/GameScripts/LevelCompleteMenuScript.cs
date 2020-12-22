using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCompleteMenuScript : MonoBehaviour
{
    public GameManagerScript GMS;

    public TextMeshProUGUI TimeLeftText;
    public TextMeshProUGUI TilesLeftText;
    public TextMeshProUGUI TimerTime;

    //Sets time left text on end screen
    public void SetTimeLeftText()
    {
        TimeLeftText.text = "Time left: " + TimerTime.text.ToString();
    }

    //Sets tiles left text on end screen
    public void SetTilesLeftText()
    {
        TilesLeftText.text = "Tiles: " + (GMS.blocksBefore - GMS.Dest.countBlocks(GMS.blocksAfter)) + "/" + GMS.blocksBefore;
    }

    //What complete screen buttons do
    public void NextLevelButton()
    {
        GMS.NextLevel();
    }

    public void RestartLevelButton()
    {
        GMS.RestartLevel();
    }

    public void MainMenuButton()
    {
        GMS.BackToMainMenu();
    }
}
