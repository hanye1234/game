using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public int GameDifficulty;
    // Update is called once per frame
    public void ChangeScene(int dif)
    {
        GameDifficulty=dif;
        PlayerPrefs.SetInt("GameDifficulty",GameDifficulty);
        SceneManager.LoadScene("MainScene");
    }
    public void totitle()
    {
        SceneManager.LoadScene("Title");
    }


}
