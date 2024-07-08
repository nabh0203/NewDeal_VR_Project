//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BGMSoundManager : MonoBehaviour
//{
//    public AudioSource[] BGMS;
//    public AudioClip[] BGMs;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Stage1"))
//        {
//            ChangeBGM(0);
//        }
//        else if (other.CompareTag("Stage2"))
//        {
//            ChangeBGM(1);
//        }
//        else if (other.CompareTag("Stage3"))
//        {
//            ChangeBGM(2);
//        }
//    }

//    private void ChangeBGM(int index)
//    {
//        if (index < BGMS.Length && index < BGMs.Length)
//        {
//            for (int i = 0; i < BGMS.Length; i++)
//            {
//                BGMS[i].clip = BGMs[index];
//                BGMS[i].Play();
//            }
//        }
//        else
//        {
//            Debug.LogWarning("Not Index");
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSoundManager : MonoBehaviour
{
    public float fadeDuration = 1.0f; // 페이드 아웃/인 시간 설정
    public AudioManager audioManager; // AudioManager 참조

    private AudioSource currentSource; // 현재 재생 중인 오디오 소스를 추적

    private void Start()
    {
        if (audioManager != null)
        {
            currentSource = audioManager.audioSource;
            audioManager.OnStartGame(); // OnStartGame() 함수 호출
            Debug.Log("튜토리얼 시작");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stage1"))
        {
            StartCoroutine(ChangeBGM(0));
            Debug.Log("Stage1");
        }
        else if (other.CompareTag("Stage2"))
        {
            StartCoroutine(ChangeBGM(1));
            Debug.Log("Stage2");
        }
        else if (other.CompareTag("Stage3"))
        {
            StartCoroutine(ChangeBGM(2));
            Debug.Log("Stage3");
        }
    }

    private IEnumerator ChangeBGM(int index)
    {
        // 현재 재생 중인 오디오 소스를 페이드 아웃
        if (currentSource != null)
        {
            yield return StartCoroutine(FadeOut(currentSource, fadeDuration));
        }

        // AudioManager를 통해 새로운 오디오 클립 재생
        switch (index)
        {
            case 0:
                audioManager.PlayStage1Music();
                break;
            case 1:
                audioManager.PlayStage2Music();
                break;
            case 2:
                audioManager.PlayStage3Music();
                break;
            default:
                Debug.LogWarning("Invalid BGM index");
                yield break;
        }

        // 새로운 오디오 소스를 페이드 인
        currentSource = audioManager.audioSource; // 현재 오디오 소스를 업데이트
        if (currentSource != null)
        {
            yield return StartCoroutine(FadeIn(currentSource, fadeDuration));
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0;
        audioSource.Play();

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }

        audioSource.volume = 1;
    }
}


