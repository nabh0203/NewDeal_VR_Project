using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTest : OVRGrabbable
{
    [Tooltip("발사되는 공 오브젝트")]
    [Header("발사되는 공 오브젝트")]
    public GameObject Ball; // 발사할 공 오브젝트

    public float baseForceAmount = 1f; // 기본 힘의 크기
    public float maxForceAmount = 10f; // 최대 힘의 크기
    private Rigidbody ballRb;
    private Vector3 initialPosition; // 큐브의 초기 위치

    private float grabStartTime; // 잡기 시작 시간

    protected override void Start()
    {
        base.Start(); // 부모 클래스의 Start() 메서드 호출

        // 큐브의 초기 위치 저장
        initialPosition = transform.position;

        if (Ball != null)
        {
            ballRb = Ball.GetComponent<Rigidbody>();
            if (ballRb == null)
            {
                Debug.LogError("Ball 오브젝트에 Rigidbody가 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Ball 오브젝트가 설정되지 않았습니다.");
        }
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        grabStartTime = Time.time; // 잡기 시작 시간 기록
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);

        float grabDuration = Time.time - grabStartTime; // 잡기 지속 시간 계산
        float forceMultiplier = Mathf.Clamp(grabDuration, 0, 1); // 지속 시간을 0에서 1 사이로 클램프
        float appliedForce = Mathf.Lerp(baseForceAmount, maxForceAmount, forceMultiplier); // 기본 힘에서 최대 힘 사이의 값을 계산

        // 공을 발사
        ThrowBall(appliedForce);

        // 큐브를 초기 위치로 이동
        StartCoroutine(ResetCubePosition());
    }

    private void ThrowBall(float forceAmount)
    {
        if (ballRb != null)
        {
            // z축 방향으로 위쪽으로 힘을 가함
            Vector3 forceDirection = new Vector3(0, 1, 1).normalized; // 위쪽과 앞으로 힘을 가하는 방향 설정
            ballRb.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
        }
    }

    private IEnumerator ResetCubePosition()
    {
        float duration = 0.2f; // 위치와 회전이 리셋되는 데 걸리는 시간
        float elapsedTime = 0.0f;

        Vector3 startingPosition = transform.position;
        Quaternion startingRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, initialPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startingRotation, Quaternion.identity, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null; // 다음 프레임까지 대기
        }

        // 위치와 회전을 최종적으로 초기 상태로 설정
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // 큐브의 속도 초기화
            rb.angularVelocity = Vector3.zero; // 큐브의 각속도 초기화
        }
    }

}
