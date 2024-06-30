using UnityEngine;

public class HandRayInteractor : MonoBehaviour
{
    public Transform rayOrigin; // 레이의 시작점
    public float rayLength = 5f; // 레이의 길이
    public LineRenderer lineRenderer; // 레이 표시를 위한 LineRenderer

    private void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    private void Update()
    {
        // OVRInput을 사용하여 오른쪽 트리거 버튼을 감지
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
