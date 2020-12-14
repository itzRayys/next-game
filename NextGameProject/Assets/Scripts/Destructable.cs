using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructable : MonoBehaviour
{
    public Transform playerPos;
    public Transform playerPoint;
    private Vector3 setTile;
    public Tilemap destructableTilemap;

    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) <= 0.3f)
        {
            setTile = playerPos.transform.position;
        }
        if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) >= 0.3f)
        {
            if (Vector3.Distance(playerPos.transform.position, setTile) >= 0.3f)
            {
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(setTile), null);
            }
        }
    }
}
