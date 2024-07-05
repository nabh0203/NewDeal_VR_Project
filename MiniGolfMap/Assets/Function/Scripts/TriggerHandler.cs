using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public Transform[] triggerPoints; // 9개의 트리거 지점을 배열로 선언
    private bool[] triggered; // 각 트리거 지점의 상태를 저장하는 배열

    void Start()
    {
        // 트리거 지점의 상태를 초기화
        triggered = new bool[triggerPoints.Length];
        for (int i = 0; i < triggered.Length; i++)
        {
            triggered[i] = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 트리거 지점 확인
        for (int i = 0; i < triggerPoints.Length; i++)
        {
            if (other.transform == triggerPoints[i])
            {
                if (!triggered[i])
                {
                    triggered[i] = true;
                    HandleTrigger(i);
                }
                break;
            }
        }
    }

    void HandleTrigger(int index)
    {
        // 트리거 발생 시 호출될 함수
        Debug.Log("Trigger point " + index + " activated.");

        // 여기에 원하는 동작을 추가하세요.
    }
}
