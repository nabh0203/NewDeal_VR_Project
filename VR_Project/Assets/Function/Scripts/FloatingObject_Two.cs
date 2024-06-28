using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject_Two : MonoBehaviour
{
    // 부유하는 속도
    public float floatSpeed = 1.0f;
    // 부유하는 높이
    public float floatHeight = 0.5f;
    // 시작 위치를 저장하기 위한 변수
    private Vector3 startPosition;

    void Start()
    {
        // 오브젝트의 시작 위치를 저장
        startPosition = transform.position;
    }

    void Update()
    {
            Gravity();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfClub"))
        {
            // 부유 시작
            enabled = false;
            Debug.Log("충돌");
        }
    }

    private void Gravity()
    {
        // 부유하는 애니메이션을 계산
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

}



