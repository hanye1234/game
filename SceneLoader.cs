using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    AsyncOperation loadingOperation;
    public Scrollbar runcharacter;

    float bargage;

    void Start() 
    {   
        bargage=0;
        loadingOperation = SceneManager.LoadSceneAsync("MainScene");
        loadingOperation.allowSceneActivation = false;
    }

    void Update()
    {
        
        if(bargage<1)
        {
            bargage+=Time.unscaledDeltaTime/2.0f;
        }
        else
        {
            bargage=1;
        }
        if(loadingOperation.progress>bargage*0.9f)
        {
            runcharacter.value=Mathf.Clamp01(bargage/1.0f);
        }
        else
        {
            runcharacter.value=Mathf.Clamp01(loadingOperation.progress/0.9f);
        }
        if(bargage==1)
        {
            bargage=0;
            StartCoroutine(delayloadTime(3));
        }
        

    }

    IEnumerator delayloadTime(float t)
    {
        yield return new WaitForSecondsRealtime(t);
        loadingOperation.allowSceneActivation = true;
    }

}
