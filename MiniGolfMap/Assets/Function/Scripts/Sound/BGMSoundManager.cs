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
    public AudioSource[] BGMS;
    public AudioClip[] BGM;
    public float fadeDuration = 1.0f; // ���̵� �ƿ�/�� �ð� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stage1"))
        {
            StartCoroutine(ChangeBGM(0));
        }
        else if (other.CompareTag("Stage2"))
        {
            StartCoroutine(ChangeBGM(1));
        }
        else if (other.CompareTag("Stage3"))
        {
            StartCoroutine(ChangeBGM(2));
        }
    }

    private IEnumerator ChangeBGM(int index)
    {
        if (index < BGMS.Length && index < BGM.Length)
        {
            // ���� ��� ���� ��� ����� �ҽ��� ���̵� �ƿ�
            foreach (AudioSource source in BGMS)
            {
                StartCoroutine(FadeOut(source, fadeDuration));
            }

            // ���̵� �ƿ��� ���� ������ ���
            yield return new WaitForSeconds(fadeDuration);

            // ���ο� ����� Ŭ������ ����
            foreach (AudioSource source in BGMS)
            {
                source.clip = BGM[index];
                source.Play();
                StartCoroutine(FadeIn(source, fadeDuration));
            }
        }
        else
        {
            Debug.LogWarning("Not Index");
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
