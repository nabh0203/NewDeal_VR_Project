using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfGrab_Two : OVRGrabbable
{
    private Rigidbody rb;
    public bool isGrab;
    // 원하는 위치와 각도를 설정할 Transform
    public Transform desiredTransform;

    protected override void Start()
    {
        isGrab = false;
        // Rigidbody 컴포넌트를 초기화합니다.
        rb = GetComponent<Rigidbody>();

        // Rigidbody가 null이면 오류 메시지를 출력합니다.
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the game object.");
        }
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            isGrab = true;

            // 오브젝트의 위치와 회전을 원하는 Transform 값으로 설정합니다.
            transform.position = desiredTransform.position;
            transform.rotation = desiredTransform.rotation;
        }
        else
        {
            Debug.LogError("Rigidbody is null in GrabBegin");
        }

        base.GrabBegin(hand, grabPoint);
    }

    // OVRGrabbable의 GrabEnd 메서드를 오버라이드합니다.
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            isGrab = false;
        }
        else
        {
            Debug.LogError("Rigidbody is null in GrabEnd");
        }
    }
}
