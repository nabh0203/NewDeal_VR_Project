using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCameraHeight : MonoBehaviour
{
    // ����� Ű�� �Է� �ޱ� ���� ����
    public float userHeight = 1.8f; // �⺻ Ű�� 1.8���ͷ� ����

    // ī�޶� ������ Transform�� �����ϱ� ���� ����
    public Transform cameraRig;

    void Start()
    {
        // cameraRig�� �������� �ʾҴٸ�, OVRCameraRig�� ã�Ƽ� ����
        if (cameraRig == null)
        {
            OVRCameraRig rig = FindObjectOfType<OVRCameraRig>();
            if (rig != null)
            {
                cameraRig = rig.transform;
            }
            else
            {
                Debug.LogError("OVRCameraRig not found in the scene.");
                return;
            }
        }

        // ����� Ű ���̿� ���� ī�޶� ���� ���� ����
        AdjustHeight();
    }

    // ����� Ű ���̿� ���� ī�޶� ���� ���̸� �����ϴ� �޼���
    void AdjustHeight()
    {
        if (cameraRig != null)
        {
            // ī�޶� ������ ���� ��ġ�� ������ ��, y�� ���̸� ����� Ű�� ����
            Vector3 newPosition = cameraRig.position;
            newPosition.y = userHeight;
            cameraRig.position = newPosition;
        }
    }

    // Inspector���� �ǽð����� ����� Ű�� ������ �� �ֵ��� ������Ʈ �޼��忡 ����
    void Update()
    {
        AdjustHeight();
    }
}
