using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructable : MonoBehaviour
{
    public Transform playerPos;
    public Transform playerPoint;
    public Transform goalTile;
    private Vector3 setTile;
    public Tilemap destructableTilemap;
    public Tile baseTile;
    public bool atGoal = false;

    private string currentTile;

    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) <= 0.3f)
        {
            if (Vector3.Distance(playerPos.transform.position, goalTile.transform.position) <= 0.3f)
            {
                atGoal = true;
            }
            else
            {
                atGoal = false;
                setTile = playerPos.transform.position;
                currentTile = destructableTilemap.GetTile(destructableTilemap.WorldToCell(setTile)).ToString();
            }
        }
        if (!atGoal)
        {
            if (currentTile == "TempTilemap_32 (UnityEngine.Tilemaps.Tile)")
            {
                if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) >= 0.3f)
                {
                    if (Vector3.Distance(playerPos.transform.position, setTile) >= 0.3f)
                    {
                        destructableTilemap.SetTile(destructableTilemap.WorldToCell(setTile), null);
                    }
                }
            }
            if (currentTile == "TempTilemap_33 (UnityEngine.Tilemaps.Tile)")
            {
                if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) >= 0.3f)
                {
                    if (Vector3.Distance(playerPos.transform.position, setTile) >= 0.3f)
                    {
                        destructableTilemap.SetTile(destructableTilemap.WorldToCell(setTile), baseTile);
                    }
                }
            }
        }
        else
        {
            Debug.Log("At Goal!");
        }
    }
}
