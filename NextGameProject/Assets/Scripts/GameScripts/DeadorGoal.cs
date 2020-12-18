using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadorGoal : MonoBehaviour
{
    public Transform Player;
    public Transform PlayerPoint;
    public Transform StartingTile;
    public Transform GoalTile;

    public PlayerDeath PD;
    public GameManagerScript GMS;

    public bool playerIsAtGoal = false;
    private bool playerIsAtGoal2 = false;


    private void LateUpdate()
    {
        if (Vector3.Distance(Player.transform.position, PlayerPoint.transform.position) <= 0.3f)
        {
            if (Vector3.Distance(Player.transform.position, GoalTile.transform.position) <= 0.3f)
            {
                playerIsAtGoal = true;
                PD.checkAtGoal = true;

                if (!playerIsAtGoal2)
                {
                    playerIsAtGoal2 = true;
                    Debug.Log("At Goal!");
                    reachedGoal();
                }
            }
            else
            {
                playerIsAtGoal = false;
            }
        }
    }

    public void reachedGoal()
    {
        Debug.Log("Player has reached the goal!");
        GMS.Timer.StopAllCoroutines();
    }
}
