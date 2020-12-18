using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public GameObject playerSprite;
    public GameObject playerMovePoint;

    [Header("Camera")]
    public GameObject Camera;

    [Header("Tiles")]
    public GameObject startPoint;
    public GameObject Goal;

    [Header("Timer")]
    public TimerScript Timer;

    [Header("Levels")]
    public LevelsClass[] Levels;


}
