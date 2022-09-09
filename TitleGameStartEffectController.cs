using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGameStartEffectController : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject titletexts;
    public GameObject buttons;
    public GameObject panel;

    bool iseffect=false;
    float effecttimetemp=0;
    float velocity=-2.2f;

    void Update()
    {
        effecttimetemp+=Time.deltaTime;

        if(iseffect==true)
        {
            titletexts.transform.Translate(new Vector3(0, velocity,0) *4 *Time.deltaTime);
            buttons.transform.Translate(new Vector3(0,-velocity,0)*2*Time.deltaTime);    
        }
        velocity+=Time.deltaTime;

        if(effecttimetemp>5 & iseffect)
        {
            for(int i=0;i<characters.Length;i++)
            {
                characters[i].SetActive(true);
            }
            iseffect=false;
        }
    }

    public void GameStartEffect()
    {
        iseffect=true;
        panel.SetActive(false);
    }


    
}
