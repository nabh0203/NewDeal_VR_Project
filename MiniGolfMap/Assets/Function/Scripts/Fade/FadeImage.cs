using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public Image fadeObject;
    public float fadeTime = 1.0f; // 페이드 아웃 시간 (초)

    private void Start()
    {
        fadeObject = GetComponent<Image>();
        fadeObject.color = new Color(fadeObject.color.r, fadeObject.color.g, fadeObject.color.b, 0); // 알파 값을 0으로 설정하여 처음에 보이지 않게 함
    }

    private void OnTriggerEnter(Collider other)
    {
        fadeObject.color = new Color(fadeObject.color.r, fadeObject.color.g, fadeObject.color.b, 1); // 알파 값을 1로 설정하여 보이게 함
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color originalColor = fadeObject.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            fadeObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, elapsedTime / fadeTime)); // 1에서 0으로 페이드 아웃
            yield return null;
        }

        // 완전히 투명하게 만들기 위해 알파 값을 0으로 설정
        fadeObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }
}
