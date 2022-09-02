using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HighScorePanelController : MonoBehaviour
{

    public TextMeshProUGUI[] High_Meter_texts;
    public TextMeshProUGUI[] High_ScorePoint_texts;
    List<int> Highscorepoints=new List<int>();
    List<int> Highscoremeters=new List<int>();
    // Start is called before the first frame update
    void Awake()
    {
        Highscorepoints.Add(PlayerPrefs.GetInt("EasyHighScorePoint"));
        Highscorepoints.Add(PlayerPrefs.GetInt("NormalHighScorePoint"));
        Highscorepoints.Add(PlayerPrefs.GetInt("HardHighScorePoint"));
        Highscoremeters.Add(PlayerPrefs.GetInt("EasyHighScoreMeter"));
        Highscoremeters.Add(PlayerPrefs.GetInt("NormalHighScoreMeter"));
        Highscoremeters.Add(PlayerPrefs.GetInt("HardHighScoreMeter"));
    }

    void Start()
    {
        for(int i=0;i<High_Meter_texts.Length;i++)
        {
            High_ScorePoint_texts[i].text=PointToDisplay(Highscorepoints[i]);
            High_Meter_texts[i].text=MeterToDisplay(Highscoremeters[i]);
        }
        
    }

    string PointToDisplay(int Point)
    {
        if(Point>=1000)
        {
            return ((Math.Round((Point/1000.0f),1)).ToString())+"kp";
        }
        else
        {
            return ((Point).ToString())+"p";
        }
    }

    string MeterToDisplay(int Meter)
    {
        if(Meter>=1000)
        {
            return ((Math.Round(Meter/1000.0f,1)).ToString())+"km";
        }
        else
        {
            return ((Meter).ToString())+"m";
        }

    }

}
