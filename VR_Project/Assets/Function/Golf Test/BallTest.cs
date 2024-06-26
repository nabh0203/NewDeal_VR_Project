using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{
    public float forceAmount = 10f; // 가할 힘의 크기
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 확인
        {
            // z축 방향으로 위쪽으로 힘을 가함
            Vector3 forceDirection = new Vector3(0, 1, 1).normalized; // 위쪽과 앞으로 힘을 가하는 방향 설정
            rb.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
        }
    }
}
