using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public int GameDifficulty;
    public AudioSource BGM;
    public GameObject[] characters;
    public GameObject canvas;
    public TitleGameStartEffectController titleGameStartEffectController;

    void Start()
    {
        Time.timeScale=1;
        
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     Invoke("PlayTitleBGM",3);
            
        // }
         
    }
    
    // Update is called once per frame
    public void ChangetoMainScene(int dif)
    {
        GameDifficulty=dif;
        PlayerPrefs.SetInt("GameDifficulty",GameDifficulty);
        StartCoroutine(StartEffect(10));
        
    }
    public void totitle()
    {
        SceneManager.LoadScene("Title");
    }

    void PlayTitleBGM()
    {
        BGM.Play();
    }

    IEnumerator StartEffect(int time)
    {
        titleGameStartEffectController.GameStartEffect();
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("Load");
    }
    
}
