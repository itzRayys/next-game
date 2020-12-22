using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;
    public Transform startPoint;
    public LayerMask whatAllowsMovement;

    public GameManagerScript GMS;

    void Start()
    {
        movePoint.parent = null;
    }

    //Script for tile-based movement
    void Update()
    {
        //Moves player towards move point
        transform.position = Vector3.MoveTowards(
            transform.position, 
            movePoint.position, 
            moveSpeed * Time.deltaTime);

        if (!GMS.PMS.isPaused)
        {
            //Only executes when player finished moving
            if (Vector3.Distance(transform.position, movePoint.position) <= .01f)
            {
                //Checks if player is trying to move horizontal or vertical
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
                {
                    //Checks if the tile the player is trying to move to is a tile that you can move onto
                    if (Physics2D.OverlapCircle(movePoint.position +
                        new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .3f, whatAllowsMovement))

                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
                {
                    //Checks if the tile the player is trying to move to is a tile that you can move onto
                    if (Physics2D.OverlapCircle(movePoint.position +
                        new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .3f, whatAllowsMovement))

                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }

    //Sets player to starting point and hides starting tile
    public void playerToStart()
    {
        transform.position = startPoint.position;
        movePoint.position = startPoint.position;
        startPoint.GetComponent<Renderer>().enabled = false;
    }
}
