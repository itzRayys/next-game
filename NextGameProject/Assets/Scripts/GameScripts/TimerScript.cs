using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    public float startTime;
    public TextMeshProUGUI timerText1;

    public float timer;

    //Timer script
    public IEnumerator Timer1()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;

            FormatText1();

            yield return null;
        }
        while(timer > 0);
    }

    //Formats time
    private void FormatText1()
    {
        if (timer > 0)
        {
            int minutes = (int)(timer / 60) % 60;
            float seconds = (float)(timer % 60);

            timerText1.text = "";
            if (minutes > 0 && minutes < 10) { timerText1.text += string.Format("{0:0}:", minutes); }
            else if (minutes > 0) { timerText1.text += string.Format("{0:00}:", minutes); }
            if (seconds > 0 && seconds < 10) { timerText1.text += string.Format("{0:0.00}", seconds); }
            else { timerText1.text += string.Format("{0:00.00}", seconds); }
        }
        else { timerText1.text = "0.00"; }
    }
}
