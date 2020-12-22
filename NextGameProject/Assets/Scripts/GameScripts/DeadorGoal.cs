using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadorGoal : MonoBehaviour
{
    public Transform Player;
    public Transform PlayerPoint;
    public Transform GoalTile;

    public GameManagerScript GMS;
    public GameObject levelCompleteUI;

    public bool playerIsAtGoal = false;


    private void LateUpdate()
    {
        if (Vector3.Distance(Player.transform.position, PlayerPoint.transform.position) <= 0.3f)
        {
            if (Vector3.Distance(Player.transform.position, GoalTile.transform.position) <= 0.3f)
            {
                if (!playerIsAtGoal)
                {
                    playerIsAtGoal = true;
                    reachedGoal();
                }
            }
        }
    }

    public void reachedGoal()
    {
        Time.timeScale = 0f;
        levelCompleteUI.SetActive(true);
        GMS.isPausable = false;
        Debug.Log("Player has reached the goal!");
        GMS.Timer.StopAllCoroutines();
        GMS.LevelCompleteScreen.GetComponent<LevelCompleteScript>().Invoke("levelComplete", 0.1f);
    }
}
