using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject_Two : MonoBehaviour
{
    // �����ϴ� �ӵ�
    public float floatSpeed = 1.0f;
    // �����ϴ� ����
    public float floatHeight = 0.5f;
    // ���� ��ġ�� �����ϱ� ���� ����
    private Vector3 startPosition;

    public ReturnBall reBall;

    public  HapticFeedback hapticFeedback;
    void Start()
    {
        // ������Ʈ�� ���� ��ġ�� ����
        startPosition = transform.position;
        if (hapticFeedback == null)
        {
            Debug.LogError("HapticFeedback ��ũ��Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    void Update()
    {
        if (reBall.isBall == true) 
        { 
            Gravity();
            //enabled = true;
            Debug.Log("���� ����");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfClub"))
        {
            if (hapticFeedback != null)
            {
                hapticFeedback.TriggerHapticFeedback(OVRInput.Controller.LTouch);
                hapticFeedback.TriggerHapticFeedback(OVRInput.Controller.RTouch);
            }
            // ���� ����
            //enabled = false;
            reBall.isBall = false;
            Debug.Log("�浹");
        }
    }

    private void Gravity()
    {
        // �����ϴ� �ִϸ��̼��� ���
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

}



