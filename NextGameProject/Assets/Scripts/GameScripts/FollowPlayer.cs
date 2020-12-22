using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    public float zoomSize;

    public GameManagerScript GMS;

    private void LateUpdate()
    {
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
        


        transform.position = player.position + offset;
    }

}
