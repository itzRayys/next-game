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

    [HideInInspector]
    public DeadorGoal DoG;
    public PlayerDeath PD;

    private void Start()
    {
        //Sets tilemap
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void LateUpdate()
    {
        //Checks if player has finished moving
        if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) <= 0.3f)
        {
            //Checks if player is at goal
            if (!DoG.playerIsAtGoal)
            {
                //If player is not at goal, gets current tile location
                setTile = playerPos.transform.position;
                currentTile = destructableTilemap.GetTile(destructableTilemap.WorldToCell(setTile)).ToString();
            }
        }

        //Checks if player is at goal
        if (!DoG.playerIsAtGoal)
        {
            //Checks current tile to see if its a base tile or "2 health" tile
            //If tile is base (1 health) the tile is destroyed
            if (currentTile == "TempTilemap_32 (UnityEngine.Tilemaps.Tile)")
            {
                //Checks if player has started moving off tile by checking that the point is checking
                //  if the next tile is movable
                if (Vector3.Distance(playerPos.transform.position, playerPoint.transform.position) >= 0.3f)
                {
                    //Checks if player has moved off the set tile 
                    if (Vector3.Distance(playerPos.transform.position, setTile) >= 0.3f)
                    {
                        //Destroys tile
                        destructableTilemap.SetTile(destructableTilemap.WorldToCell(setTile), null);
                    }
                }
            }
            //If tile is a "2 health tile" the tile is set to the base "1 health" tile instead of being destroyed
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

    //Counts how many tiles there are currently (called at the beginning of the level to see how many tiles are
    //  in the level, then at the end to see how many the play destroyed) (Counts "2 health tiles" as one tile)
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
