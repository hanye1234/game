using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameovertextDisplay : MonoBehaviour
{
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        GameObject target=gameObject;
    }

    void OnEnable() {
        GameObject target=gameObject;
        FadeIn(5.0f,1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn(float fadeOutTime,float finishalpha, System.Action nextEvent = null){
		StartCoroutine(CoFadeIn(fadeOutTime,finishalpha,nextEvent));
	}

	// 투명 -> 불투명
	IEnumerator CoFadeIn(float fadeOutTime, float finishalpha, System.Action nextEvent = null){
		TextMeshProUGUI sr = GetComponent<TextMeshProUGUI>();
		Color tempColor = sr.color;
		while(tempColor.a < finishalpha){
			tempColor.a += Time.unscaledDeltaTime / fadeOutTime;
			sr.color = tempColor;

			if(tempColor.a >= finishalpha) tempColor.a = finishalpha;

			yield return null;
		}

		sr.color = tempColor;
		if(nextEvent != null) nextEvent();
	}
}
