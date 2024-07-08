using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSFX : MonoBehaviour
{
    public AudioManager BGM;
    public float fadeInDuration = 2.0f; // ���̵� �� ���� �ð�

    private void Start()
    {
        // ���� AudioManager�� PlayEndingMusic() �޼��带 ȣ���Ͽ� ������� ����մϴ�.
        BGM.PlayEndingMusic();

        // AudioManager�� audioSource�� �����ͼ� ���̵� ���� �����մϴ�.
        StartCoroutine(FadeIn(BGM.audioSource, fadeInDuration));
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        if (audioSource == null)
        {
            yield break;
        }

        audioSource.volume = 0;
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 1, t / duration);
            yield return null;
        }

        audioSource.volume = 1;
    }
}
