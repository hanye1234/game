using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resumegamecountdown : MonoBehaviour
{
    float stoptime=0;
    int count=0;
    TextMeshProUGUI mytext;
    public bool isStopnow=false;
    void Start() {
        mytext=GetComponent<TextMeshProUGUI>();
        stoptime=0;
    }

    void OnEnable() {
        stoptime=0;
        count=0;
        isStopnow=true;
        
    }
    // Update is called once per frame
    void Update()
    {
        stoptime=stoptime+Time.unscaledDeltaTime;
        if(stoptime>1 & count==0)
        {
            mytext.text=(2).ToString();
            count=1;
        }
        else if(stoptime>2&count==1)
        {
            mytext.text=(1).ToString();
            count=2;
        }
        else if(stoptime>3&count==2)
        {
            mytext.text="START!";
            count=3;
        }
        if(stoptime>4)
        {
            isStopnow=false;
            mytext.text=(3).ToString();
            gameObject.SetActive(false);
        }
    }
}
