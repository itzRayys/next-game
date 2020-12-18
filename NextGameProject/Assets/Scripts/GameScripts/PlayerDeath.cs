using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDeath : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask whatAllowsMovement;
    public Destructable dest;
    public GameManagerScript GMS;

    public bool checkAtGoal = false;
    public bool dead = false;


    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .01f)
        {
            if (!checkAtGoal)
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
        Debug.Log("Player has died!");
    }
}
