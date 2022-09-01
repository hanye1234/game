using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayer : MonoBehaviour
{
    public GameObject[] Players;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<Players.Length;i++){
            Players[i].SetActive(false);
        }
        Players[gameController.GameDifficulty].SetActive(true);

    }

}
