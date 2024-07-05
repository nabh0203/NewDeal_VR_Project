using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
    public float shootPower = 10f; // �߻� �Ŀ�, ����Ƽ �����Ϳ��� ���� ����
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from this game object");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (rb != null)
        {
            rb.AddForce(transform.forward * shootPower, ForceMode.Impulse); // ���� Z������ ���� ���մϴ�.
        }
    }
}
