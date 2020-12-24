using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDeath : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask whatAllowsMovement;
    public GameManagerScript GMS;

    public DeathScreenScript DSS;
    public GameObject DeathScreenUI;

    public DeadorGoal DoG;
    public bool dead = false;


    private void Update()
    {
        //Checks when player can't move anywhere and sets player to dead as long as player is not at goal
        if (Vector3.Distance(transform.position, movePoint.position) <= .01f)
        {
            if (!DoG.playerIsAtGoal)
            {
                if (!Physics2D.OverlapCircle(movePoint.position +
                    new Vector3(1f, 0f, 0f), .01f, whatAllowsMovement) &&
                    !Physics2D.OverlapCircle(movePoint.position +
                    new Vector3(-1f, 0f, 0f), .01f, whatAllowsMovement) &&
                    !Physics2D.OverlapCircle(movePoint.position +
                    new Vector3(0f, 1f, 0f), .01f, whatAllowsMovement) &&
                    !Physics2D.OverlapCircle(movePoint.position +
                    new Vector3(0f, -1f, 0f), .01f, whatAllowsMovement))
                {
                    if (!dead) 
                    { 
                        PlayerHasDied();
                        dead = true;
                    }
                }
            }
        }
        //Kills player when time is up
        if (!dead && GMS.timeUp)
        {
            PlayerHasDied();
            dead = true;
        }
    }

    //What happens when player dies (Death screen is set active, checks if player died to time or movement and
    //  sets text accordingly
    public void PlayerHasDied()
    {
        GMS.Timer.StopAllCoroutines();
        if (GMS.timeUp)
        {
            DSS.DiedFromTime();
            Debug.Log("Died because time");
        }
        else
        {
            DSS.DiedFromTiles();

            Debug.Log("Died because tiles");
        }
        GMS.isPausable = false;
        Time.timeScale = 0f;
        DeathScreenUI.SetActive(true);
    }
}
