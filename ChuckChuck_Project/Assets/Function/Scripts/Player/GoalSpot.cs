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
        // Ʈ���ſ� �������� �� ����Ǵ� �Լ�
        MoveToTargetPosition();
    }

    private void MoveToTargetPosition()
    {
        // ���� ������Ʈ�� targetPosition�� ��ġ�� �̵���ŵ�ϴ�.
        Player.transform.position = NextStage.position;
    }
}
