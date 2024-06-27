using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public Rigidbody golfStick;
    public Rigidbody golfBall; // 골프공의 Rigidbody
    public float minHeight = 0.5f; // 최소 높이
    public float maxHeight = 2.0f; // 최대 높이
    public float minForce = 5.0f; // 최소 힘
    public float maxForce = 20.0f; // 최대 힘

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

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolfBall"))
        {
            golfStick.isKinematic = false;
            golfStick.useGravity = true;
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
        // 골프채가 공과 충돌했을 때
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            // 골프채의 높이를 가져옵니다.
            float clubHeight = transform.position.y;

            // 높이에 따라 힘을 선형적으로 조절합니다.
            float forceMultiplier = Mathf.InverseLerp(minHeight, maxHeight, clubHeight);
            float appliedForce = Mathf.Lerp(minForce, maxForce, forceMultiplier);

            // 공의 속도를 조절합니다.
            Vector3 hitDirection = collision.contacts[0].point - transform.position;
            hitDirection = hitDirection.normalized;

            // 공에 힘을 가합니다.
            golfBall.velocity = appliedForce * hitDirection;
            
        }
    }
}
