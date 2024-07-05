using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FadeOut : MonoBehaviour
{
    public GameObject fadeObject;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2.0f; // 페이드 아웃 지속 시간
    private bool swhichStage;
    public DOTweenAnimation textAnimation;

    void Start()
    {
        fadeObject.SetActive(false);
        canvasGroup = fadeObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = fadeObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1f;
        swhichStage = true; // 초기화
    }

    private void OnTriggerEnter(Collider other)
    {
        if (swhichStage)
        {
            fadeObject.SetActive(true);
            VR_Fade_NBH.instance.FadeIn();
            textAnimation.DOPlay();
            Invoke("StartFadeOut", 2f);
        }
    }

    private void StartFadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;
            yield return null;
        }

        // 페이드 아웃이 완료된 후 오브젝트를 비활성화하거나 삭제할 수 있습니다.
        // fadeObject.SetActive(false);
        // 또는
        // Destroy(fadeObject);
        swhichStage = false; // 페이드 아웃 완료 후 상태 초기화
    }
}
