using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI mytext;
    public PlayerController playercontroller;
    public BackGroundController background;
    float score;
    float local_starttime;

    // Start is called before the first frame update
    void Start()
    {
        score=0;
        local_starttime=0;
        mytext=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(local_starttime<5){
            local_starttime=local_starttime+Time.deltaTime;
        }
        else{
            score=score+background.speed*(1+playercontroller.combo/100)*Time.deltaTime/100;
            mytext.text=(Math.Floor(score*10)*10).ToString();
        }
        
    }
}
