using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfSwing : MonoBehaviour
{
    public Transform vrControllerTransform; // vr ��Ʈ�ѷ��� Ʈ������
    public float swingForce = 500f; // ����ä�� �� ����

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
            // ����ä�� ��ġ�� ȸ���� VR ��Ʈ�ѷ��� ���� �̵���ŵ�ϴ�.
            rb.MovePosition(vrControllerTransform.position);
            rb.MoveRotation(vrControllerTransform.rotation);

            // ���� ��ġ ����
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
                // ���� ��ġ�� ���� ��ġ�� ����Ͽ� �ӵ��� ����մϴ�.
                Vector3 velocity = (transform.position - previousPosition) / Time.fixedDeltaTime;

                // ���� ������ ����մϴ� (����ä�� �̵� ����).
                Vector3 forceDirection = velocity.normalized;

                // ���� ���� ���մϴ�.
                ballRigidbody.AddForce(forceDirection * swingForce);

                Debug.Log("Golf ball hit! Force applied. Velocity: " + velocity);
            }
        }
    }
}
