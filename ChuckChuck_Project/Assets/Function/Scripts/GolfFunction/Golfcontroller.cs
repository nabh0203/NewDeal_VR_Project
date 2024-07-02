using UnityEngine;

public class GolfController : MonoBehaviour
{
    public Rigidbody golfBall; // 골프공의 Rigidbody

    private Vector3 lastPosition; // 골프채의 이전 프레임 위치
    private Vector3 velocity; // 골프채의 속도

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // 골프채의 속도를 계산합니다.
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 골프채가 공과 충돌했을 때
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            // 공의 속도를 조절합니다.
            Vector3 hitDirection = collision.contacts[0].point - transform.position;
            hitDirection = hitDirection.normalized;

            // 공에 힘을 가합니다.
            golfBall.velocity = velocity.magnitude * hitDirection;
        }
    }
}
