/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualHandGrabbable : OVRGrabbable
{
    protected OVRGrabber m_secondaryGrabbedBy = null;
    protected Collider m_secondaryGrabbedCollider = null;

    public OVRGrabber secondaryGrabbedBy
    {
        get { return m_secondaryGrabbedBy; }
    }

    public Transform secondaryGrabbedTransform
    {
        get { return m_secondaryGrabbedCollider != null ? m_secondaryGrabbedCollider.transform : null; }
    }

    public void SecondaryGrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        m_secondaryGrabbedBy = hand;
        m_secondaryGrabbedCollider = grabPoint;
    }

    public void SecondaryGrabEnd()
    {
        m_secondaryGrabbedBy = null;
        m_secondaryGrabbedCollider = null;
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        if (m_grabbedBy == null)
        {
            base.GrabBegin(hand, grabPoint);
        }
        else if (m_secondaryGrabbedBy == null)
        {
            SecondaryGrabBegin(hand, grabPoint);
        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        if (m_secondaryGrabbedBy != null)
        {
            SecondaryGrabEnd();
        }
        else
        {
            base.GrabEnd(linearVelocity, angularVelocity);
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    void FixedUpdate()
    {
        if (m_grabbedBy != null && m_secondaryGrabbedBy != null)
        {
            Vector3 primaryHandPosition = m_grabbedBy.transform.position;
            Vector3 secondaryHandPosition = m_secondaryGrabbedBy.transform.position;
            Vector3 midPoint = (primaryHandPosition + secondaryHandPosition) / 2;

            Quaternion primaryHandRotation = m_grabbedBy.transform.rotation;
            Quaternion secondaryHandRotation = m_secondaryGrabbedBy.transform.rotation;
            Quaternion midRotation = Quaternion.Slerp(primaryHandRotation, secondaryHandRotation, 0.5f);

            transform.position = midPoint;
            transform.rotation = midRotation;
        }
    }
}
*/

using UnityEngine;

public class DualHandGrabbable : OVRGrabbable
{
    private OVRGrabber leftHandGrabber;
    private OVRGrabber rightHandGrabber;

    protected override void Start()
    {
        base.Start();
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        if (hand.CompareTag("LeftHand"))
        {
            leftHandGrabber = hand;
        }
        else if (hand.CompareTag("RightHand"))
        {
            rightHandGrabber = hand;
        }

        // 두 손으로 동시에 잡고 있을 때의 처리
        if (leftHandGrabber != null && rightHandGrabber != null)
        {
            // 두 손으로 잡고 있는 동안 특정 기능을 추가할 수 있습니다.
        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);

        if (m_grabbedBy.CompareTag("LeftHand"))
        {
            leftHandGrabber = null;
        }
        else if (m_grabbedBy.CompareTag("RightHand"))
        {
            rightHandGrabber = null;
        }

        // 손을 놓았을 때의 처리
        if (leftHandGrabber == null && rightHandGrabber == null)
        {
            // 두 손 모두 놓았을 때 특정 기능을 추가할 수 있습니다.
        }
    }
}
