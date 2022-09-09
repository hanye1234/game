using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornController : MonoBehaviour
{
    public GameObject[] corns;
    int randomidx;

    // bool isGeneratecorn=true;

    void Start()
    {

    }

    void OnEnable()
    {
        Generatecorn();
    }

    void Update()
    {   
        // if(background.position.x<=-39 & isGeneratecorn){
        //     isGeneratecorn=false;
        //     Generatecorn();
        // }
        // if(background.position.x>=18 & !isGeneratecorn)
        // {
        //     isGeneratecorn=true;

        //     for(int i=0; i<corns.Length;i++){
        //     corns[i].SetActive(false);
        //     }
        // }
    }

    void OnDisable()
    {
        corns[randomidx].SetActive(false);    
    }

    void Generatecorn(){
        randomidx=Random.Range(0,corns.Length);
        corns[randomidx].SetActive(true);
    }
}
