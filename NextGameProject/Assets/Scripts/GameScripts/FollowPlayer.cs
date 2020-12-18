using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    public float zoomSize;

    private void LateUpdate()
    {
        // Hold to zoom out
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Camera>().orthographicSize = zoomSize;
        }
        else
        {
            GetComponent<Camera>().orthographicSize = 7;
        }

        //Toggle zoom out
        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(GetComponent<Camera>().orthographicSize == 7)
            {
                GetComponent<Camera>().orthographicSize = zoomSize;
            }
            else
            {
                GetComponent<Camera>().orthographicSize = 7;
            }
        }
        */


        transform.position = player.position + offset;
    }

}
