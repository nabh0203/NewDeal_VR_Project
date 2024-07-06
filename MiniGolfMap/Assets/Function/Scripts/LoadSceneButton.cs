using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneButton : MonoBehaviour
{
    public string SceneName;
    //public CanvasGroup canvasGroup; // CanvasGroup ������Ʈ�� ����Ͽ� Canvas�� ������ ����
    //public GameObject canvas; // CanvasGroup ������Ʈ�� ����Ͽ� Canvas�� ������ ����
    public DOTweenAnimation openDoorOne;
    public DOTweenAnimation openDoorTwo;

    public Material hologram;
    public VR_Fade_NBH vrFade; // Reference to the VR_Fade_NBH script

    public AudioManager BGM;
    public AudioSource startVFX;
    public AudioClip buttonClick;
    public AudioClip openDoor;

    public GameObject smokeParticle;
    public Transform smokePosition;

    private void Start()
    {
        //hologram �ȿ� FADE_ON , HOLOGRAM_ON Setbool �̿��ؼ� ���ֱ�
        hologram.DisableKeyword("FADE_ON");
        hologram.DisableKeyword("HOLOGRAM_ON");
        hologram.DOFloat(-0.1f, "_FadeAmount", 3f);
        hologram.DOFloat(0.1f, "_BurnTransition", 3f);

        // Ensure vrFade is assigned
        if (vrFade == null)
        {
            vrFade = VR_Fade_NBH.instance;
        }
    }

    public void OnClickButton()
    {
        startVFX.PlayOneShot(buttonClick);
        Debug.Log("��ư ����");
        // 2�� �Ŀ� �۸�ġ ȿ���� ��Ȱ��ȭ
        StartCoroutine(GlitchEffect());
    }

    private IEnumerator GlitchEffect()
    {
        hologram.EnableKeyword("FADE_ON");
        hologram.EnableKeyword("HOLOGRAM_ON");
        //hologram �ȿ� FADE_ON , HOLOGRAM_ON Setbool �̿��ؼ� ���ֱ�
        // Ȧ�α׷� ȿ�� Ȱ��ȭ
        hologram.DOFloat(22f, "_StripesAmount", 3f);
        hologram.DOFloat(22f, "_UnChangedAmount", 3f);
        hologram.DOFloat(1f, "_StripesSpeed", 3f);
        hologram.DOFloat(1f, "_FadeAmount", 3f);
        hologram.DOFloat(1f, "_BurnTransition", 3f);
        //canvas.SetActive(false);
        yield return new WaitForSeconds(4f);
        OpenDoors();
    }

    private void OpenDoors()
    {
        // ���ϴ� �ִϸ��̼� ȿ���� ���� (���⼭�� ���� 90�� ȸ���ϴ� ����)
        openDoorOne.DOPlay();
        openDoorTwo.DOPlay();
        Instantiate(smokeParticle, smokePosition.position, Quaternion.identity);
        Destroy(smokeParticle, 1f);
        startVFX.PlayOneShot(openDoor);
        // �ִϸ��̼��� ���� �� �� �ε�
        DOVirtual.DelayedCall(5f, () => FadeOut());
        DOVirtual.DelayedCall(7f, () => SceneManager.LoadScene(SceneName));
        DOVirtual.DelayedCall(6f, () => StartCoroutine(FadeOut(BGM.audioSource, 1f)));
        DOVirtual.DelayedCall(7f, () => DOTween.KillAll());
        // Start the fade-out effect
        
    }

    private void FadeOut()
    {
        if (vrFade != null)
        {
            vrFade.FadeOut();
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
}
