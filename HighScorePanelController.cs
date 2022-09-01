using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            High_Meter_texts[i].text=((Highscoremeters[i]).ToString())+"m";
            High_ScorePoint_texts[i].text=((Highscorepoints[i]).ToString())+"p";
        }
        
    }

}
