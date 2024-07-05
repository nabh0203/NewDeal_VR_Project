using UnityEngine;
using DG.Tweening;

public class GolfBallController : MonoBehaviour
{
    public Transform startPoint; // 시작점
    public Transform endPoint; // 끝점
    public Transform[] pathPoints; // 경로를 구성하는 포인트들
    public float baseDuration = 10f; // 기본 이동 시간
    private bool isMoving = false; // 공이 이동 중인지 확인하는 플래그
    private Rigidbody rb; // 공의 Rigidbody 컴포넌트

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartPoint") && !isMoving) // 트리거된 오브젝트가 StartPoint 태그를 가지고 있는지 확인
        {
            MoveAlongPath();
        }
    }

    void MoveAlongPath()
    {
        isMoving = true; // 이동 시작
        Vector3[] path = new Vector3[pathPoints.Length + 2];
        path[0] = startPoint.position; // 시작점 추가
        for (int i = 0; i < pathPoints.Length; i++)
        {
            path[i + 1] = pathPoints[i].position;
        }

        path[pathPoints.Length + 1] = endPoint.position; // 끝점 추가

        // 공의 속도에 비례하여 duration 계산
        float speed = rb.velocity.magnitude; // 최소 속도 적용
        float duration = baseDuration / speed; // 속도에 반비례하여 이동 시간 설정

        rb.isKinematic = true;

        // 경로를 따라 이동
        transform.DOPath(path, 1f, PathType.CatmullRom)
           .SetEase(Ease.Linear) // 이동의 완화 유형 설정
           .OnComplete(OnPathComplete) // 경로 이동 완료 후 호출될 메서드 설정
           .SetLookAt(0.1f); // 경로를 따라 이동할 때 회전 설정

    }

    void OnPathComplete()
    {
        Debug.Log("Path completed!");
        isMoving = false; // 이동 완료
        rb.isKinematic = false; // kinematic 모드 해제하여 물리 영향을 받도록 함

        //rb.velocity = Vector3.zero; // 공의 속도 초기화
        //rb.angularVelocity = Vector3.zero; // 공의 각속도 초기화
            
        //rb.AddForce(Physics.gravity, ForceMode.Acceleration); // 중력에 따른 힘 적용
       
    }
}