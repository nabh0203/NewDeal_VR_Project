using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandRayInteractor : MonoBehaviour
{
    //public Transform rayOrigin; // 레이의 시작점
    //public float rayLength = 5f; // 레이의 길이
    //public LineRenderer lineRenderer; // 레이 표시를 위한 LineRenderer

    //private void Start()
    //{
    //    if (lineRenderer == null)
    //    {
    //        lineRenderer = GetComponent<LineRenderer>();
    //    }
    //}

    //private void Update()
    //{
    //    // OVRInput을 사용하여 오른쪽 트리거 버튼을 감지
    //    if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
    //    {
    //        DisplayRay(true);
    //    }
    //    else
    //    {
    //        DisplayRay(false);
    //    }
    //}

    //private void DisplayRay(bool isActive)
    //{
    //    if (isActive)
    //    {
    //        lineRenderer.enabled = true;
    //        lineRenderer.SetPosition(0, rayOrigin.position);
    //        lineRenderer.SetPosition(1, rayOrigin.position + rayOrigin.forward * rayLength);
    //    }
    //    else
    //    {
    //        lineRenderer.enabled = false;
    //    }
    //}

    public LineRenderer lineRenderer;
    public Transform controllerTransform;
    public LayerMask uiLayerMask;
    public float laserLength = 10.0f;

    void Update()
    {
        lineRenderer.enabled = true;
        // 트리거 버튼 눌림 감지
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Ray ray = new Ray(controllerTransform.position, controllerTransform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, laserLength, uiLayerMask))
            {
                lineRenderer.SetPosition(0, controllerTransform.position);
                lineRenderer.SetPosition(1, hit.point);

                // UI 요소와 상호작용
                if (hit.collider.gameObject.GetComponent<Button>())
                {
                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                    }
                }
            }
            else
            {
                lineRenderer.SetPosition(0, controllerTransform.position);
                lineRenderer.SetPosition(1, controllerTransform.position + controllerTransform.forward * laserLength);
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
