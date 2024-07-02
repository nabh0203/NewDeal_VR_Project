using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public Image fadeObject;
    public float fadeTime = 1.0f; // ���̵� �ƿ� �ð� (��)

    private void Start()
    {
        fadeObject = GetComponent<Image>();
        fadeObject.color = new Color(fadeObject.color.r, fadeObject.color.g, fadeObject.color.b, 0); // ���� ���� 0���� �����Ͽ� ó���� ������ �ʰ� ��
    }

    private void OnTriggerEnter(Collider other)
    {
        fadeObject.color = new Color(fadeObject.color.r, fadeObject.color.g, fadeObject.color.b, 1); // ���� ���� 1�� �����Ͽ� ���̰� ��
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color originalColor = fadeObject.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            fadeObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, elapsedTime / fadeTime)); // 1���� 0���� ���̵� �ƿ�
            yield return null;
        }

        // ������ �����ϰ� ����� ���� ���� ���� 0���� ����
        fadeObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }
}
