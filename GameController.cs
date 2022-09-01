using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int GameSpeed;
    public int GameDifficulty;
    public GameObject countdown;
    public GameObject Gameoverobj;
    void Awake() {
        Screen.SetResolution(1280,720,true);
        GameDifficulty=PlayerPrefs.GetInt("GameDifficulty");
        GameSpeed=10;
    }

    void Start()
    {
        PauseGame();
        ResumeGame();
        
        // GameDifficulty=PlayerPrefs.GetInt("GameDifficulty");
    }

    public void PauseGame()
    {
        Time.timeScale=0;
    }

    public void ResumeGame()
    {
        countdown.SetActive(true);
    }

    public void Gameover()
    {
        PauseGame();
        Gameoverobj.SetActive(true);
        
    }

    public void GameRetry()
    {
        Gameoverobj.SetActive(false);
    }
    
}
