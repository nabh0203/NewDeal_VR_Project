using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public Transform wormholeExit;
    public float absorptionSpeed = 5f;
    public float exitYOffset = 1f; // wormholeExit의 y축으로 이동할 오프셋 값
    public float exitSpeed = 2f; // 물체를 y축으로 밀어내는 속도
    public float launchForce = 10f; // 발사 힘
    private bool isAbsorbing = false;
    private bool isExiting = false;
    private GameObject ball;
    private Rigidbody rb; // Rigidbody를 클래스 멤버로 선언

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ball = other.gameObject;
            rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            isAbsorbing = true;
        }
    }

    void Update()
    {
        if (isAbsorbing && ball != null)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, transform.position, absorptionSpeed * Time.deltaTime);

            if (Vector3.Distance(ball.transform.position, transform.position) < 0.1f)
            {
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }

                ball.transform.position = wormholeExit.position;
                isAbsorbing = false;
                isExiting = true;
            }
        }

        if (isExiting && ball != null)
        {
            // wormholeExit의 로컬 y축으로 이동
            Vector3 localOffset = wormholeExit.TransformPoint(Vector3.up * exitYOffset);
            Vector3 targetPosition = new Vector3(localOffset.x, localOffset.y, localOffset.z);
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, targetPosition, exitSpeed * Time.deltaTime);

            // 밀어내는 동안 Rigidbody 물리력을 계속 0으로 유지
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            if (Vector3.Distance(ball.transform.position, targetPosition) < 0.1f)
            {
                isExiting = false;

                // 발사 힘을 가함
                if (rb != null)
                {
                    rb.AddForce(wormholeExit.up * launchForce, ForceMode.Impulse);
                }

                ball = null;
            }
        }
    }
}
