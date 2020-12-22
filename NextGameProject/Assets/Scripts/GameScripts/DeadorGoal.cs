using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadorGoal : MonoBehaviour
{
    public Transform Player;
    public Transform PlayerPoint;
    public Transform GoalTile;

    public GameManagerScript GMS;

    public bool playerIsAtGoal = false;

    //Checks when player is at goal
    private void LateUpdate()
    {
        if (Vector3.Distance(Player.transform.position, PlayerPoint.transform.position) <= 0.3f)
        {
            if (Vector3.Distance(Player.transform.position, GoalTile.transform.position) <= 0.3f)
            {
                if (!playerIsAtGoal)
                {
                    GMS.reachedGoal();
                    playerIsAtGoal = true;
                }
            }
        }
    }

    
}
