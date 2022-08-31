using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int GameSpeed;
    public string GameDifficulty;

    void Awake() {
        Screen.SetResolution(1280,720,true);
    }

    void Start()
    {
        GameSpeed=10;    
    }


}
