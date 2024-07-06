using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        VR_Fade_NBH.instance.FadeOut();
        other.gameObject.SetActive(false);

        StartCoroutine(ExecuteAfterDelay(1f)); // 1�� ���� �� ����Ǵ� �ڷ�ƾ ����
    }

    private IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(FadeAudioSource(audioSource, 1f, 0f, 1f));
        yield return new WaitForSeconds(1f); // FadeAudioSource�� ������ 1�� �Ŀ� �� �ε�
        SceneManager.LoadScene("Ending");
    }

    private IEnumerator FadeAudioSource(AudioSource source, float startVolume, float endVolume, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            source.volume = Mathf.Lerp(startVolume, endVolume, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        source.volume = endVolume;
    }
}
