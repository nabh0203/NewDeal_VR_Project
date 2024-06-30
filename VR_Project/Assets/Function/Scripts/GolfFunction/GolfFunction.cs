using UnityEngine;
using OculusSampleFramework;

public class GolfFunction : MonoBehaviour
{
    public Transform clubHead; // 골프채의 헤드
    public Rigidbody golfBall; // 골프 공
    public Transform vrController; // VR 컨트롤러 (오른손)

    public float swingForceMultiplier = 10f; // 스윙 힘 배수
    public float maxYForce = 5f; // 공의 최대 Y축 힘

    private Vector3 lastPosition; // 이전 프레임의 클럽 위치
    private Vector3 velocity; // 클럽의 속도
    private Quaternion lastRotation; // 이전 프레임의 클럽 회전
    private Vector3 angularVelocity; // 클럽의 각속도

    void Start()
    {
        lastPosition = clubHead.position;
        lastRotation = clubHead.rotation;
    }

    void Update()
    {
        // VR 컨트롤러의 위치와 회전을 클럽에 반영
        clubHead.position = vrController.position;
        clubHead.rotation = vrController.rotation;

        // 클럽의 속도 계산
        velocity = (clubHead.position - lastPosition) / Time.deltaTime;
        lastPosition = clubHead.position;

        // 클럽의 각속도 계산
        angularVelocity = (clubHead.rotation.eulerAngles - lastRotation.eulerAngles) / Time.deltaTime;
        lastRotation = clubHead.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 골프채가 골프 공과 충돌할 때
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            // 클럽의 속도와 각속도를 사용하여 힘을 계산
            Vector3 force = velocity * swingForceMultiplier;
            Vector3 angularForce = angularVelocity * swingForceMultiplier * 0.1f; // 각속도를 통한 추가 힘

            // 공에 가해질 총 힘 계산
            Vector3 totalForce = force + angularForce;

            // Y축 힘을 최대 값으로 클램핑
            totalForce.y = Mathf.Clamp(totalForce.y, -Mathf.Infinity, maxYForce);

            // 공에 힘을 가함
            golfBall.AddForce(totalForce, ForceMode.Impulse);
        }
    }
}
