using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public Transform[] triggerPoints; // 9���� Ʈ���� ������ �迭�� ����
    private bool[] triggered; // �� Ʈ���� ������ ���¸� �����ϴ� �迭

    void Start()
    {
        // Ʈ���� ������ ���¸� �ʱ�ȭ
        triggered = new bool[triggerPoints.Length];
        for (int i = 0; i < triggered.Length; i++)
        {
            triggered[i] = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Ʈ���� ���� Ȯ��
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
        // Ʈ���� �߻� �� ȣ��� �Լ�
        Debug.Log("Trigger point " + index + " activated.");

        // ���⿡ ���ϴ� ������ �߰��ϼ���.
    }
}
