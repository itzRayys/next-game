using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    public float zoomSize;

    public GameManagerScript GMS;

    private void LateUpdate()
    {
        // Checks if game is paused
        if (!GMS.PMS.isPaused)
        {
            /*
                    // Hold to zoom out
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        GetComponent<Camera>().orthographicSize = zoomSize;
                    }
                    else
                    {
                        GetComponent<Camera>().orthographicSize = 7;
                    }
                    */


            //Toggle zoom out
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (GetComponent<Camera>().orthographicSize == 7)
                {
                    GetComponent<Camera>().orthographicSize = zoomSize;
                }
                else
                {
                    GetComponent<Camera>().orthographicSize = 7;
                }
            }
        }
        

        // Moves camera to follow the player, offset prevents camera from going first person
        transform.position = player.position + offset;
    }

}
