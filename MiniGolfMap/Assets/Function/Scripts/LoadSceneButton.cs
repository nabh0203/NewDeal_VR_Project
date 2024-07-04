using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneButton : MonoBehaviour
{
    public string SceneName;
    public CanvasGroup canvasGroup; // CanvasGroup ������Ʈ�� ����Ͽ� Canvas�� ������ ����
    public DOTweenAnimation openDoorOne;
    public DOTweenAnimation openDoorTwo;

    public void OnClickButton()
    {
        Debug.Log("��ư ����");

        // Canvas�� ������ ������� �ϴ� �ִϸ��̼�
        canvasGroup.DOFade(0, 1f).OnComplete(() =>
        {
            // Canvas�� ����� �� �� �ִϸ��̼� ����
            OpenDoors();
        });
    }

    private void OpenDoors()
    {
        // ���ϴ� �ִϸ��̼� ȿ���� ���� (���⼭�� ���� 90�� ȸ���ϴ� ����)
        openDoorOne.DOPlay();
        openDoorTwo.DOPlay();
        // �ִϸ��̼��� ���� �� �� �ε�
        DOVirtual.DelayedCall(1f, () => SceneManager.LoadScene(SceneName));
        VR_Fade_NBH.instance.FadeOut();
    }
}
