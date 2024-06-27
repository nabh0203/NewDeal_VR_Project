using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfGrab_Two : OVRGrabbable
{
    private Rigidbody rb;
    public bool isGrab;
    // ���ϴ� ��ġ�� ������ ������ Transform
    public Transform desiredTransform;

    protected override void Start()
    {
        isGrab = false;
        // Rigidbody ������Ʈ�� �ʱ�ȭ�մϴ�.
        rb = GetComponent<Rigidbody>();

        // Rigidbody�� null�̸� ���� �޽����� ����մϴ�.
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

            // ������Ʈ�� ��ġ�� ȸ���� ���ϴ� Transform ������ �����մϴ�.
            transform.position = desiredTransform.position;
            transform.rotation = desiredTransform.rotation;
        }
        else
        {
            Debug.LogError("Rigidbody is null in GrabBegin");
        }

        base.GrabBegin(hand, grabPoint);
    }

    // OVRGrabbable�� GrabEnd �޼��带 �������̵��մϴ�.
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
