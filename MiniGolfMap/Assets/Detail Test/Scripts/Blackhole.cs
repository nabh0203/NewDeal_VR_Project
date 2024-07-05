using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public Transform wormholeExit;
    public float absorptionSpeed = 5f;
    public float exitYOffset = 1f; // wormholeExit�� y������ �̵��� ������ ��
    public float exitSpeed = 2f; // ��ü�� y������ �о�� �ӵ�
    public float launchForce = 10f; // �߻� ��
    private bool isAbsorbing = false;
    private bool isExiting = false;
    private GameObject ball;
    private Rigidbody rb; // Rigidbody�� Ŭ���� ����� ����

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
            // wormholeExit�� ���� y������ �̵�
            Vector3 localOffset = wormholeExit.TransformPoint(Vector3.up * exitYOffset);
            Vector3 targetPosition = new Vector3(localOffset.x, localOffset.y, localOffset.z);
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, targetPosition, exitSpeed * Time.deltaTime);

            // �о�� ���� Rigidbody �������� ��� 0���� ����
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            if (Vector3.Distance(ball.transform.position, targetPosition) < 0.1f)
            {
                isExiting = false;

                // �߻� ���� ����
                if (rb != null)
                {
                    rb.AddForce(wormholeExit.up * launchForce, ForceMode.Impulse);
                }

                ball = null;
            }
        }
    }
}
