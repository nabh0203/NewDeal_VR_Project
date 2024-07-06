using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneButton : MonoBehaviour
{
    public string SceneName;
    //public CanvasGroup canvasGroup; // CanvasGroup 컴포넌트를 사용하여 Canvas의 투명도를 조절
    //public GameObject canvas; // CanvasGroup 컴포넌트를 사용하여 Canvas의 투명도를 조절
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
        //hologram 안에 FADE_ON , HOLOGRAM_ON Setbool 이용해서 꺼주기
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
        Debug.Log("버튼 눌림");
        // 2초 후에 글리치 효과를 비활성화
        StartCoroutine(GlitchEffect());
    }

    private IEnumerator GlitchEffect()
    {
        hologram.EnableKeyword("FADE_ON");
        hologram.EnableKeyword("HOLOGRAM_ON");
        //hologram 안에 FADE_ON , HOLOGRAM_ON Setbool 이용해서 켜주기
        // 홀로그램 효과 활성화
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
        // 원하는 애니메이션 효과를 설정 (여기서는 문이 90도 회전하는 예시)
        openDoorOne.DOPlay();
        openDoorTwo.DOPlay();
        Instantiate(smokeParticle, smokePosition.position, Quaternion.identity);
        Destroy(smokeParticle, 1f);
        startVFX.PlayOneShot(openDoor);
        // 애니메이션이 끝난 후 씬 로드
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
