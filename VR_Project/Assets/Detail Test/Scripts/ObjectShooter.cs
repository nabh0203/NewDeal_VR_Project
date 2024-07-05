using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
    public float shootPower = 10f; // 발사 파워, 유니티 에디터에서 조절 가능
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
            rb.AddForce(transform.forward * shootPower, ForceMode.Impulse); // 로컬 Z축으로 힘을 가합니다.
        }
    }
}
