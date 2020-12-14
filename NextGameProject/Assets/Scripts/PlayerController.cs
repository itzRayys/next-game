using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatAllowsMovement;

    void Start()
    {
        movePoint.parent = null;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            movePoint.position, 
            moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .01f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                if(Physics2D.OverlapCircle(movePoint.position + 
                    new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .3f, whatAllowsMovement))

                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                if (Physics2D.OverlapCircle(movePoint.position +
                    new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .3f, whatAllowsMovement))

                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
    }
}
