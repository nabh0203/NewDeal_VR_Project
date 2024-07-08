using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfSwing : MonoBehaviour
{
    public Transform vrControllerTransform; // vr 컨트롤러의 트랜스폼
    public float swingForce = 500f; // 골프채의 힘 세기

    private Vector3 previousPosition;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from golf club.");
        }

        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (vrControllerTransform != null && rb != null)
        {
            // 골프채의 위치와 회전을 VR 컨트롤러에 맞춰 이동시킵니다.
            rb.MovePosition(vrControllerTransform.position);
            rb.MoveRotation(vrControllerTransform.rotation);

            // 이전 위치 갱신
            previousPosition = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                // 현재 위치와 이전 위치를 사용하여 속도를 계산합니다.
                Vector3 velocity = (transform.position - previousPosition) / Time.fixedDeltaTime;

                // 힘의 방향을 계산합니다 (골프채의 이동 방향).
                Vector3 forceDirection = velocity.normalized;

                // 공에 힘을 가합니다.
                ballRigidbody.AddForce(forceDirection * swingForce);

                Debug.Log("Golf ball hit! Force applied. Velocity: " + velocity);
            }
        }
    }
}
