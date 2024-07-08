using UnityEngine;

public class OVRGolfClub : MonoBehaviour
{
    public OVRInput.Controller controller; // OVR ��Ʈ�ѷ�
    public float swingPower = 10f; // ���� ���� ��
    public Transform golfClubTransform; // ����ä�� Transform

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, controller)) // Ʈ���� ��ư �Է�
        {
            Swing();
        }
    }

    void Swing()
    {
        // OVR ��Ʈ�ѷ��� ȸ�� ���� ���
        Vector3 clubDirection = golfClubTransform.forward;

        // �������� ���� ����
        OVRGolfBall.Instance.HitBall(clubDirection, swingPower);
    }
}
