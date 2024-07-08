using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public Rigidbody golfStick;
    public Rigidbody golfBall; // �������� Rigidbody
    public float minHeight = 0.5f; // �ּ� ����
    public float maxHeight = 2.0f; // �ִ� ����
    public float minForce = 5.0f; // �ּ� ��
    public float maxForce = 20.0f; // �ִ� ��

    private Vector3 lastPosition; // ����ä�� ���� ������ ��ġ
    private Vector3 velocity; // ����ä�� �ӵ�

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // ����ä�� �ӵ��� ����մϴ�.
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
        // ����ä�� ���� �浹���� ��
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            // ����ä�� ���̸� �����ɴϴ�.
            float clubHeight = transform.position.y;

            // ���̿� ���� ���� ���������� �����մϴ�.
            float forceMultiplier = Mathf.InverseLerp(minHeight, maxHeight, clubHeight);
            float appliedForce = Mathf.Lerp(minForce, maxForce, forceMultiplier);

            // ���� �ӵ��� �����մϴ�.
            Vector3 hitDirection = collision.contacts[0].point - transform.position;
            hitDirection = hitDirection.normalized;

            // ���� ���� ���մϴ�.
            golfBall.velocity = appliedForce * hitDirection;
            
        }
    }
}
