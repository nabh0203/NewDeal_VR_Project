using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Transform ballTransform; // ���� Transform
    public Collider goalCollider; // �� ������ Collider
    public Image image; // ���̵� ȿ���� �� �̹���
    public float fadeDuration = 2.0f; // ���̵��� �� ���̵�ƿ� �ð�
    public float displayDuration = 2.0f; // ���̵��� �� �̹����� �����Ǵ� �ð�

    private bool hasGoalBeenReached = false; // ���� �� �����ߴ��� ����

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
        // ���̵���
        yield return StartCoroutine(Fade(0, 1));

        // �̹����� ���� �ð� ���� ����
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
