using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    public float startTime;
    [SerializeField] TextMeshProUGUI timerText1;

    private float timer;


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

    private void FormatText1()
    {

        int minutes = (int)(timer / 60) % 60;
        float seconds = (float)(timer % 60);

        timerText1.text = "";
        if (minutes > 0 && minutes < 10) { timerText1.text += string.Format("{0:0}:", minutes);  }
        else if (minutes > 0) { timerText1.text += string.Format("{0:00}:", minutes); }
        timerText1.text += string.Format("{0:00.000}", seconds);
    }
}
