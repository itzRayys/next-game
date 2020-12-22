using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructable : MonoBehaviour
{
    public Transform playerPos;
    public Transform playerPoint;
    public Transform goalTile;
    public Tilemap destructableTilemap;

    private Vector3 setTile;
    public Tile baseTile;
    private string currentTile;

    public BoundsInt area;
    public int blocksBefore;
    public int blocksAfter;

    [HideInInspector]
    public DeadorGoal DoG;
    public PlayerDeath PD;

    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) <= 0.3f)
        {
            if (!DoG.playerIsAtGoal)
            {
                setTile = playerPos.transform.position;
                currentTile = destructableTilemap.GetTile(destructableTilemap.WorldToCell(setTile)).ToString();
            }
        }

        if (!DoG.playerIsAtGoal)
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
    }
    public int countBlocks(int blocks)
    {
        TileBase[] tileArray = destructableTilemap.GetTilesBlock(area);
        for (int index = 0; index < tileArray.Length; index++)
        {
            if (tileArray[index] != null)
            {
                blocks++;
            }
        }
        return blocks -= 1;
    }
}
