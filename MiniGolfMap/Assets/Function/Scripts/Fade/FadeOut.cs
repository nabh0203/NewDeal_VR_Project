using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FadeOut : MonoBehaviour
{
    public GameObject fadeObject;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2.0f; // ���̵� �ƿ� ���� �ð�
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
        swhichStage = true; // �ʱ�ȭ
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

        // ���̵� �ƿ��� �Ϸ�� �� ������Ʈ�� ��Ȱ��ȭ�ϰų� ������ �� �ֽ��ϴ�.
        // fadeObject.SetActive(false);
        // �Ǵ�
        // Destroy(fadeObject);
        swhichStage = false; // ���̵� �ƿ� �Ϸ� �� ���� �ʱ�ȭ
    }
}
