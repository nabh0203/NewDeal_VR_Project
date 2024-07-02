    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantBall : MonoBehaviour
{
    public Vector3 fixedForce; // ������ ��

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // �ܺο��� ������ ��� ���� ��ȿȭ
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // ������ �� ����
        rb.AddForce(fixedForce, ForceMode.Force);
    }
}
