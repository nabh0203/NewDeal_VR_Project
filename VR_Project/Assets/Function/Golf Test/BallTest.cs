using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{
    public float forceAmount = 10f; // ���� ���� ũ��
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� Ȯ��
        {
            // z�� �������� �������� ���� ����
            Vector3 forceDirection = new Vector3(0, 1, 1).normalized; // ���ʰ� ������ ���� ���ϴ� ���� ����
            rb.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
        }
    }
}
