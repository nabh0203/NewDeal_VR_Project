using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneButton : MonoBehaviour
{
    public string SceneName;
    public CanvasGroup canvasGroup; // CanvasGroup 컴포넌트를 사용하여 Canvas의 투명도를 조절
    public DOTweenAnimation openDoorOne;
    public DOTweenAnimation openDoorTwo;

    public void OnClickButton()
    {
        Debug.Log("버튼 눌림");

        // Canvas를 서서히 사라지게 하는 애니메이션
        canvasGroup.DOFade(0, 1f).OnComplete(() =>
        {
            // Canvas가 사라진 후 문 애니메이션 실행
            OpenDoors();
        });
    }

    private void OpenDoors()
    {
        // 원하는 애니메이션 효과를 설정 (여기서는 문이 90도 회전하는 예시)
        openDoorOne.DOPlay();
        openDoorTwo.DOPlay();
        // 애니메이션이 끝난 후 씬 로드
        DOVirtual.DelayedCall(1f, () => SceneManager.LoadScene(SceneName));
        VR_Fade_NBH.instance.FadeOut();
    }
}
