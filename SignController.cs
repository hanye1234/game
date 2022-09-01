using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignController : MonoBehaviour
{
    public GameObject[] PanelCharacters;
    public GameController gameController;
    bool isGeneratePanel=true;
    float Localdistance;
    public float Totaldistance;
    int GeneratedCharaterIndex;
    public TextMeshProUGUI[] Meter_texts;

    public BackGroundController backGroundController;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<PanelCharacters.Length;i++){
            PanelCharacters[i].SetActive(false);
        }
        Localdistance=0;
        Totaldistance=0;
    }

    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Localdistance=Localdistance+Time.deltaTime*backGroundController.speed/1.5f;
        if(Localdistance>=100&isGeneratePanel)
        {
            Totaldistance=Totaldistance+Localdistance;
            Localdistance=0;
            Vector3 POS =transform.position;
            transform.position=new Vector3(-10,POS.y,POS.z);
            GeneratedCharaterIndex=Random.Range(0,PanelCharacters.Length);
            GeneratePanelCharaters(GeneratedCharaterIndex);
            TextMeshProUGUI mytext=Meter_texts[GeneratedCharaterIndex];
            mytext.text=((int)Totaldistance).ToString();
            isGeneratePanel=false;
        }
        if(Localdistance>=20 & isGeneratePanel==false)
        {
            PanelCharacters[GeneratedCharaterIndex].SetActive(false);
            isGeneratePanel=true;
        }
        transform.Translate(new Vector3(backGroundController.speed, 0,0) * Time.deltaTime);
    }

    void GeneratePanelCharaters(int idx)
    {
        PanelCharacters[idx].SetActive(true);
    }
}