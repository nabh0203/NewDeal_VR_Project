using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Transform ballTransform; // 공의 Transform
    public Collider goalCollider; // 골 지점의 Collider
    public Image image; // 페이드 효과를 줄 이미지
    public float fadeDuration = 2.0f; // 페이드인 및 페이드아웃 시간
    public float displayDuration = 2.0f; // 페이드인 후 이미지가 유지되는 시간

    private bool hasGoalBeenReached = false; // 공이 골에 도달했는지 여부

    private void OnTriggerEnter(Collider other)
    {
        if (!hasGoalBeenReached && other.transform == ballTransform)
        {
            hasGoalBeenReached = true;
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        // 페이드인
        yield return StartCoroutine(Fade(0, 1));

        // 이미지가 일정 시간 동안 유지
        yield return new WaitForSeconds(displayDuration);
        
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0.0f;
        Color color = image.color;
        color.a = startAlpha;
        image.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            image.color = color;
            yield return null;
        }
    }
}
