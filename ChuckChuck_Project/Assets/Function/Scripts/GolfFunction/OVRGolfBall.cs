using UnityEngine;

public class OVRGolfBall : MonoBehaviour
{
    public static OVRGolfBall Instance; // �̱��� ������ ���� �ν��Ͻ�

    private Rigidbody rb;

    void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    public void HitBall(Vector3 direction, float power)
    {
        // ���� ���� ����
        Vector3 force = direction * power;
        rb.AddForce(force, ForceMode.Impulse);

        // ����� �α׷� ���� ���
        Debug.Log($"���� ������ ��: {force}");
    }
}
