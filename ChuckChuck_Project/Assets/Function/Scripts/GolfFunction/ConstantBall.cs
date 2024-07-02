    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantBall : MonoBehaviour
{
    public Vector3 fixedForce; // 고정된 힘

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 외부에서 가해진 모든 힘을 무효화
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 고정된 힘 적용
        rb.AddForce(fixedForce, ForceMode.Force);
    }
}
