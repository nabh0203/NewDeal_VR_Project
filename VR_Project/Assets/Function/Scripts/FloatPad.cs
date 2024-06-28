using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� FloatingObject ��ũ��Ʈ�� ������ �ִ��� Ȯ��
        FloatingObject floatingObject = collision.gameObject.GetComponent<FloatingObject>();
        if (floatingObject != null)
        {
            // ���� ȿ���� Ȱ��ȭ
            floatingObject.enabled = true;
        }
    }
}
