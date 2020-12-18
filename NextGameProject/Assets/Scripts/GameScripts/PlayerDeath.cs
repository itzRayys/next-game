using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDeath : MonoBehaviour
{
    public Transform movePoint;
    public LayerMask whatAllowsMovement;
    public Destructable dest;

    public bool atEnd = false;


    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .01f)
        {
            if (!atEnd)
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
                    Debug.Log("Dead");
                }
            }
        }
    }
}
