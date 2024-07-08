using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody rb;
    public GameObject platform; // 발판 오브젝트를 연결할 변수

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false; // 우주에서는 중력이 없으므로 비활성화합니다.

        // 발판 오브젝트를 플레이어 위치에 맞추

        {
            platform.transform.SetParent(this.transform); // 발판을 플레이어의 자식으로 설정
            platform.transform.localPosition = new Vector3(0, -2, 0); // 발판의 위치를 플레이어 아래로 설정
        }
    }

    void Update()
    {
        Vector2 joystickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 moveDirection = new Vector3(joystickInput.x, 0, joystickInput.y);

        // Transform the direction relative to the player's view
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0; // Ensure we only move horizontally

        rb.velocity = moveDirection * speed;
    }
}
