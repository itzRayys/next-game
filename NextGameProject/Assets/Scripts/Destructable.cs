using System.Collections;
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

    public BoundsInt area;
    public int blocksBefore;
    public int blocksAfter;
    private bool atEnd = false;


    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();

        TileBase[] tileArray = destructableTilemap.GetTilesBlock(area);
        for (int index = 0; index < tileArray.Length; index++)
        {
            if (tileArray[index] != null)
            {
                blocksBefore++;
            }
        }
        blocksBefore -= 1;
        print(blocksBefore);
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
            if (!atEnd)
            {
                TileBase[] tileArray = destructableTilemap.GetTilesBlock(area);
                for (int index = 0; index < tileArray.Length; index++)
                {
                    if (tileArray[index] != null)
                    {
                        blocksAfter++;
                    }
                }
                blocksAfter -= 1;
                print(blocksAfter);
                atEnd = true;
                Debug.Log("At Goal!");
            }
        }
    }
}
