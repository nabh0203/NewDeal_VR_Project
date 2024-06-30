using UnityEngine;

public class HandRayInteractor : MonoBehaviour
{
    public Transform rayOrigin; // ������ ������
    public float rayLength = 5f; // ������ ����
    public LineRenderer lineRenderer; // ���� ǥ�ø� ���� LineRenderer

    private void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    private void Update()
    {
        // OVRInput�� ����Ͽ� ������ Ʈ���� ��ư�� ����
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            DisplayRay(true);
        }
        else
        {
            DisplayRay(false);
        }
    }

    private void DisplayRay(bool isActive)
    {
        if (isActive)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, rayOrigin.position);
            lineRenderer.SetPosition(1, rayOrigin.position + rayOrigin.forward * rayLength);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
