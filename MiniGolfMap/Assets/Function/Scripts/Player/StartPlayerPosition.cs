using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerPosition : MonoBehaviour
{
    public Vector3 fixedPosition = new Vector3(0, 1, 0); // 고정할 위치

    void Start()
    {
        // 플레이어를 고정된 위치로 설정
        SetFixedPosition();
        transform.rotation = transform.localRotation;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void SetFixedPosition()
    {
        transform.position = fixedPosition;
    }
}

    
