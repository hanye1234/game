using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int GameSpeed;
    public int GameDifficulty=0;
    public int HighScore=0;
    public int HighScoreMeter=0;
    public GameObject countdown;
    public GameObject Gameoverobj;
    public Button PauseButton;
    public ScoreController scoreController;
    public BackGroundController[] background;
    public SignController signController;

    class GameSettingValue{

        List<string> PlayerCharacterList = new List<string>() { "Mayu", "Amamiya", "Luca"};
        List<int> GameSpeedList=new List<int>(){10,14,18};
        List<string> GameModeNameList=new List<string>{"Easy","Normal","Hard"};

        public string GetPlayerCharacterName(int CharIdx)
        {
            return PlayerCharacterList[CharIdx];
        }

        public int GetGameSpeed(int Difficulty)
        {
            return GameSpeedList[Difficulty];
        }

        public string GetModeName(int Difficulty)
        {
            return GameModeNameList[Difficulty];
        }
    }

    GameSettingValue gameSettingValue=new GameSettingValue();


    void Awake() {
        Screen.SetResolution(1280,720,true);
        GameDifficulty=PlayerPrefs.GetInt("GameDifficulty");
        HighScore=PlayerPrefs.GetInt((gameSettingValue.GetModeName(GameDifficulty))+"HighScorePoint");
        HighScoreMeter=PlayerPrefs.GetInt((gameSettingValue.GetModeName(GameDifficulty))+"HighScoreMeter");
        GameSpeed=gameSettingValue.GetGameSpeed(GameDifficulty);
    }

    void Start()
    {
        PauseGame();
        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale=0;
        PauseButton.enabled=false;
    }

    public void ResumeGame()
    {
        countdown.SetActive(true);
        Invoke("PauseButtonDisplay",0.1f);
    }

    void PauseButtonDisplay()
    {
        PauseButton.enabled=true;
    }

    public void Gameover()
    {
        PauseGame();
        
        int curScore=(int)(Mathf.Floor(scoreController.score*10))*10;
        int curmeter=(int)(signController.Totaldistance);

        if(HighScore<curScore)
        {
            HighScore=curScore;
        }
        if(HighScoreMeter<curmeter)
        {
            HighScoreMeter=curmeter;
        }

        GameSave(); 

        Gameoverobj.SetActive(true);
        
    }

    public void GameRetry(int difficulty)
    {
        GameDifficulty=difficulty;
        PlayerPrefs.SetInt("GameDifficulty",GameDifficulty);
        Gameoverobj.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
    
    public void GameSave()
    {
        string modename=gameSettingValue.GetModeName(GameDifficulty);
        PlayerPrefs.SetInt(modename+"HighScorePoint",HighScore);
        PlayerPrefs.SetInt(modename+"HighScoreMeter",HighScoreMeter);
    }

    public void ResetGameSpeed()
    {
        for(int i=0;i<background.Length;i++)
            {
                background[i].speed=GameSpeed;
            }
            
    }

    public void SetGameSpeed(int Speed)
    {
        for(int i=0;i<background.Length;i++)
            {
                background[i].speed=Speed;
            }
    }
}
