using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfGrab : OVRGrabbable
{
    public GameObject GolfStick;
    public GameObject HandGolfStick;
    public GameObject Hand;

    private Rigidbody rb;
    public bool isGrab;
    /*public Transform GolfPosition;

    public Transform GolfReturnposition;
*/

    protected override void Start()
    {
        isGrab = false;
        // Rigidbody ������Ʈ�� �ʱ�ȭ�մϴ�.
        rb = GetComponent<Rigidbody>();
        HandGolfStick.SetActive(false);
        // Rigidbody�� null�̸� ���� �޽����� ����մϴ�.
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the game object.");
        }
        
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Hand.SetActive(false);
        HandGolfStick.SetActive(true);
        GolfStick.SetActive(false);

        if (rb != null)
        {
            isGrab = true;
            // ������Ʈ�� ȸ���� ���ϴ� ������ �����մϴ�.
            //transform.rotation = Quaternion.Euler(desiredRotation);
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
    }

}
