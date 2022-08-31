using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public GameObject[] hearts;

    int HP;
    int maxHP;
    public PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<playercontroller.health;i++){
            hearts[i].SetActive(true);
        }
        maxHP=hearts.Length;
    }

    public void HPminus(){
        playercontroller.health--;

        if(playercontroller.health<0)
        {
            playercontroller.health=0;
        }

        hearts[playercontroller.health].SetActive(false);
    }
    
    public void HPplus(){
        playercontroller.health++;

        if(playercontroller.health>maxHP){
            playercontroller.health=maxHP;
        }

        hearts[playercontroller.health-1].SetActive(true);
    }
}
