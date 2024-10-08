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
        // Rigidbody 컴포넌트를 초기화합니다.
        rb = GetComponent<Rigidbody>();
        HandGolfStick.SetActive(false);
        // Rigidbody가 null이면 오류 메시지를 출력합니다.
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
            // 오브젝트의 회전을 원하는 각도로 설정합니다.
            //transform.rotation = Quaternion.Euler(desiredRotation);
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
    }

}
