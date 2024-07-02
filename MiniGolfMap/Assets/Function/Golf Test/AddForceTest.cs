using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTest : OVRGrabbable
{
    [Tooltip("�߻�Ǵ� �� ������Ʈ")]
    [Header("�߻�Ǵ� �� ������Ʈ")]
    public GameObject Ball; // �߻��� �� ������Ʈ

    public float baseForceAmount = 1f; // �⺻ ���� ũ��
    public float maxForceAmount = 10f; // �ִ� ���� ũ��
    private Rigidbody ballRb;
    private Vector3 initialPosition; // ť���� �ʱ� ��ġ

    private float grabStartTime; // ��� ���� �ð�

    protected override void Start()
    {
        base.Start(); // �θ� Ŭ������ Start() �޼��� ȣ��

        // ť���� �ʱ� ��ġ ����
        initialPosition = transform.position;

        if (Ball != null)
        {
            ballRb = Ball.GetComponent<Rigidbody>();
            if (ballRb == null)
            {
                Debug.LogError("Ball ������Ʈ�� Rigidbody�� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("Ball ������Ʈ�� �������� �ʾҽ��ϴ�.");
        }
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        grabStartTime = Time.time; // ��� ���� �ð� ���
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);

        float grabDuration = Time.time - grabStartTime; // ��� ���� �ð� ���
        float forceMultiplier = Mathf.Clamp(grabDuration, 0, 1); // ���� �ð��� 0���� 1 ���̷� Ŭ����
        float appliedForce = Mathf.Lerp(baseForceAmount, maxForceAmount, forceMultiplier); // �⺻ ������ �ִ� �� ������ ���� ���

        // ���� �߻�
        ThrowBall(appliedForce);

        // ť�긦 �ʱ� ��ġ�� �̵�
        StartCoroutine(ResetCubePosition());
    }

    private void ThrowBall(float forceAmount)
    {
        if (ballRb != null)
        {
            // z�� �������� �������� ���� ����
            Vector3 forceDirection = new Vector3(0, 1, 1).normalized; // ���ʰ� ������ ���� ���ϴ� ���� ����
            ballRb.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
        }
    }

    private IEnumerator ResetCubePosition()
    {
        float duration = 0.2f; // ��ġ�� ȸ���� ���µǴ� �� �ɸ��� �ð�
        float elapsedTime = 0.0f;

        Vector3 startingPosition = transform.position;
        Quaternion startingRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, initialPosition, elapsedTime / duration);
            transform.rotation = Quaternion.Slerp(startingRotation, Quaternion.identity, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null; // ���� �����ӱ��� ���
        }

        // ��ġ�� ȸ���� ���������� �ʱ� ���·� ����
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // ť���� �ӵ� �ʱ�ȭ
            rb.angularVelocity = Vector3.zero; // ť���� ���ӵ� �ʱ�ȭ
        }
    }

}
