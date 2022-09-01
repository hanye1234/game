using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeinoutScript : MonoBehaviour
{
    public GameObject target;

    public void FadeIn(float fadeOutTime,float finishalpha, System.Action nextEvent = null){
		StartCoroutine(CoFadeIn(fadeOutTime,finishalpha,nextEvent));
	}

	public void FadeOut(float fadeOutTime, System.Action nextEvent = null){
		StartCoroutine(CoFadeOut(fadeOutTime, nextEvent));
	}

	// 투명 -> 불투명
	IEnumerator CoFadeIn(float fadeOutTime, float finishalpha, System.Action nextEvent = null){
		Image sr = target.GetComponent<Image>();
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

	// 불투명 -> 투명
	IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null){
		Image sr = target.GetComponent<Image>();
		Color tempColor = sr.color;
		while(tempColor.a > 0f){
			tempColor.a -= Time.unscaledDeltaTime / fadeOutTime;
			sr.color = tempColor;

			if(tempColor.a <= 0f) tempColor.a = 0f;

			yield return null;
		}
		sr.color = tempColor;
		if(nextEvent != null) nextEvent();
	}
}
