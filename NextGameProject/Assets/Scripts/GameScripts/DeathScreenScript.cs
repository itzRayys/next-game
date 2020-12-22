using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathScreenScript : MonoBehaviour
{
    public TextMeshProUGUI ReasonText;

    //Sets reason why player lost
    public void DiedFromTime()
    {
        ReasonText.text = "Time Ran Out!";
    }

    public void DiedFromTiles()
    {
        ReasonText.text = "You ran out of places to move!";
    }
}
