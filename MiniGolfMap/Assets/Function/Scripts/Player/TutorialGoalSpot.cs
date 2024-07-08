using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGoalSpot : MonoBehaviour
{
    public GameObject Player;
    //public GameObject GoalParticle;
    public Transform NextStage;
    public float delay = 2.0f; // Unity �����Ϳ��� ���� ������ ������ �ð�
    public DOTweenAnimation openDoorOne;
    public DOTweenAnimation openDoorTwo;
    public AudioClip openDoor;
    public AudioSource startVFX;

    public GameObject smokeParticle;
    public Transform smokePosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolfBall"))
        {
            // Ʈ���ſ� �������� �� ����Ǵ� �Լ�
            //MoveToTargetPosition();
            other.gameObject.SetActive(false);
            //VR_Fade_NBH.instance.FadeOut();
            OpenDoors();
            //Instantiate(GoalParticle, transform.position , Quaternion.identity);
        }
    }

    //public void MoveToTargetPosition()
    //{
       
    //}
    private void OpenDoors()
    {
        openDoorOne.DOPlay();
        openDoorTwo.DOPlay();
        startVFX.PlayOneShot(openDoor);
        Instantiate(smokeParticle, smokePosition.position, Quaternion.identity);
        DOVirtual.DelayedCall(2f, () => VR_Fade_NBH.instance.FadeOut());
        DOVirtual.DelayedCall(2f, () => StartCoroutine(MoveAfterDelay(delay)));
        DOVirtual.DelayedCall(4f, () => DOTween.KillAll());
    }
    private IEnumerator MoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (Player == null)
        {
            Debug.LogError("Player is not assigned in GoalSpot script.");
            yield break;
        }

        if (NextStage == null)
        {
            Debug.LogError("NextStage is not assigned in GoalSpot script.");
            yield break;
        }
        

        // ���� ������Ʈ�� targetPosition�� ��ġ�� �̵���ŵ�ϴ�.
        Player.transform.position = NextStage.position;
        Debug.Log("Player moved to the next stage position after delay.");
    }
}
