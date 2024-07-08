using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody rb;
    public GameObject platform; // ���� ������Ʈ�� ������ ����

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false; // ���ֿ����� �߷��� �����Ƿ� ��Ȱ��ȭ�մϴ�.

        // ���� ������Ʈ�� �÷��̾� ��ġ�� ����

        {
            platform.transform.SetParent(this.transform); // ������ �÷��̾��� �ڽ����� ����
            platform.transform.localPosition = new Vector3(0, -2, 0); // ������ ��ġ�� �÷��̾� �Ʒ��� ����
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
