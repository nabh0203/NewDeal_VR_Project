using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerPosition : MonoBehaviour
{
    public Vector3 fixedPosition = new Vector3(0, 1, 0); // ������ ��ġ

    void Start()
    {
        // �÷��̾ ������ ��ġ�� ����
        SetFixedPosition();
        transform.rotation = transform.localRotation;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void SetFixedPosition()
    {
        transform.position = fixedPosition;
    }
}

    
