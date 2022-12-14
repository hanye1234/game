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
    public Camera maincamera;
    public CanvasScaler maincanvas;
    public AudioClip[] soundeffects;
    public AudioSource SEaudioSource;
    public AudioSource BGMaudioSource;

    float currentScreenWidth;
    float currentScreenHeight;

    class GameSettingValue{

        List<string> PlayerCharacterList = new List<string>() { "Mayu", "Amamiya", "Luca"};
        List<int> GameSpeedList=new List<int>(){10,14,18};
        List<string> GameModeNameList=new List<string>{"Easy","Normal","Hard"};
        Dictionary<string, int> SoundDictionary=new Dictionary<string,int>()
        {
            {"Jump",0},
            {"Damaged",1},
            {"Countdown",2}
        };

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

        public int GetSoundNametoIndex(string Name)
        {
            return SoundDictionary[Name];
        }
    }

    GameSettingValue gameSettingValue=new GameSettingValue();


    void Awake() {
        // Screen.SetResolution(1280,720,true);
        GameDifficulty=PlayerPrefs.GetInt("GameDifficulty");
        HighScore=PlayerPrefs.GetInt((gameSettingValue.GetModeName(GameDifficulty))+"HighScorePoint");
        HighScoreMeter=PlayerPrefs.GetInt((gameSettingValue.GetModeName(GameDifficulty))+"HighScoreMeter");
        GameSpeed=gameSettingValue.GetGameSpeed(GameDifficulty);
        currentScreenWidth=(float)Screen.width;
        currentScreenHeight=(float)Screen.height;


    }

    void Start()
    {
        PauseGame();
        ResumeGame();
        
    }

    private void Update() {
        // if(currentScreenHeight>currentScreenWidth)
        // {
        //     maincamera.orthographicSize=16;
        //     maincanvas.matchWidthOrHeight=0;
        // }
    }

    public void PauseGame()
    {
        Time.timeScale=0;
        PauseButton.enabled=false;
    }

    public void ResumeGame()
    {
        countdown.SetActive(true);
        PlaySoundEffect("Countdown");
        StartCoroutine(TimeStart(4));
        Invoke("PauseButtonDisplay",0.1f);
    }

    public void TimeStop()
    {
        Time.timeScale=0;
    }

    // public void TimeStart()
    // {
    //     Time.timeScale=1;
    // }
    IEnumerator TimeStart(int t)
    {
        yield return new WaitForSecondsRealtime(t);
        Time.timeScale=1;
        countdown.SetActive(false);
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
                background[i].speed=GameSpeed*background[i].initialspeed;
            }
            
    }

    public void SetGameSpeed(int Speed)
    {
        for(int i=0;i<background.Length;i++)
            {
                background[i].speed=Speed*background[i].initialspeed;
            }
    }

    public void PlaySoundEffect(string soundName)
    {
        int Soundindex=gameSettingValue.GetSoundNametoIndex(soundName);
        SEaudioSource.PlayOneShot(soundeffects[Soundindex]);
    }

    public void PlayBackGroundMusic()
    {
        BGMaudioSource.Play();
    }

    public void StopBGM()
    {}

    public void ClearAudioSource()
    {}
}
