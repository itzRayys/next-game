using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDeath : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask whatAllowsMovement;
    public GameManagerScript GMS;

    public DeadorGoal DoG;
    public bool dead = false;


    private void LateUpdate()
    {
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
                    if (!dead) { PlayerHasDied(); }
                    dead = true;
                }
            }
        }
    }

    public void PlayerHasDied()
    {
        GMS.Timer.StopAllCoroutines();
        GMS.isPausable = false;
        Debug.Log("Player has died!");
    }
}
