using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public GameObject[] hearts;
    Dictionary<int,int> HPs=new Dictionary<int,int>()
    {
        {0,5},
        {1,3},
        {2,2},
    };
    int HP;
    int maxHP;
    public GameController gameController;

    void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        HP=HPs[gameController.GameDifficulty];
        maxHP=hearts.Length;
        for(int i=0; i<maxHP;i++){
            hearts[i].SetActive(false);
        }
        for(int i=0; i<HP;i++){
            hearts[i].SetActive(true);
        }


        
    }


    public int HPminus(){
        HP--;

        if(HP<0)
        {
            HP=0;
        }

        hearts[HP].SetActive(false);
        return HP;
    }
    
    public int HPplus(){
        HP++;

        if(HP>maxHP){
            HP=maxHP;
        }

        hearts[HP-1].SetActive(true);
        return HP;
    }
}
