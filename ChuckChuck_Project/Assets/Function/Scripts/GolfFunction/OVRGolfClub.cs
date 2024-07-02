using UnityEngine;

public class OVRGolfClub : MonoBehaviour
{
    public OVRInput.Controller controller; // OVR 컨트롤러
    public float swingPower = 10f; // 공에 가할 힘
    public Transform golfClubTransform; // 골프채의 Transform

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, controller)) // 트리거 버튼 입력
        {
            Swing();
        }
    }

    void Swing()
    {
        // OVR 컨트롤러의 회전 각도 계산
        Vector3 clubDirection = golfClubTransform.forward;

        // 골프공에 힘을 가함
        OVRGolfBall.Instance.HitBall(clubDirection, swingPower);
    }
}
