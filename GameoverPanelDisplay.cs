using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameoverPanelDisplay : MonoBehaviour
{

    public FadeinoutScript fadeinout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() {
        fadeinout.target=this.gameObject;
        fadeinout.FadeIn(5.0f,0.7f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    

}
