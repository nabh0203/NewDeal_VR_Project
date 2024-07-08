using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSFX : MonoBehaviour
{
    public AudioManager BGM;
    public float fadeInDuration = 2.0f; // 페이드 인 지속 시간

    private void Start()
    {
        // 먼저 AudioManager의 PlayEndingMusic() 메서드를 호출하여 오디오를 재생합니다.
        BGM.PlayEndingMusic();

        // AudioManager의 audioSource를 가져와서 페이드 인을 적용합니다.
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
