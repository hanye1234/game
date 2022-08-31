using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelController : MonoBehaviour
{
    public GameObject meter;
    TextMeshProUGUI mytext;
    RectTransform rectTransform;
    Vector2 text_len;
    float text_width;

    // Start is called before the first frame update
    void Start()
    {
        mytext=meter.GetComponent<TextMeshProUGUI>();
        rectTransform=GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        text_len = mytext.GetPreferredValues();
        text_width=text_len[0];
        rectTransform.sizeDelta=new Vector2(text_width*1.25f,1.5f);
    }


}