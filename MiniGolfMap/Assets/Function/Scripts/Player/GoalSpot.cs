using System.Collections;
using UnityEngine;

public class GoalSpot : MonoBehaviour
{
    public GameObject Player;
    //public GameObject GoalParticle;
    public Transform NextStage;
    public float delay = 2.0f; // Unity 에디터에서 조정 가능한 딜레이 시간

    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 진입했을 때 실행되는 함수
        MoveToTargetPosition();
        other.gameObject.SetActive(false);
        VR_Fade_NBH.instance.FadeOut();
        //Instantiate(GoalParticle, transform.position , Quaternion.identity);
    }

    public void MoveToTargetPosition()
    {
        StartCoroutine(MoveAfterDelay(delay));
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

        // 게임 오브젝트를 targetPosition의 위치로 이동시킵니다.
        Player.transform.position = NextStage.position;
        Debug.Log("Player moved to the next stage position after delay.");
    }
}

