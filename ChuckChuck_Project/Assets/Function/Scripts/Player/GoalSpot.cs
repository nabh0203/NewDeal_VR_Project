using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalSpot : MonoBehaviour
{
    public GameObject Player;
    public Transform NextStage;
    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 진입했을 때 실행되는 함수
        MoveToTargetPosition();
    }

    private void MoveToTargetPosition()
    {
        // 게임 오브젝트를 targetPosition의 위치로 이동시킵니다.
        Player.transform.position = NextStage.position;
    }
}
