using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 FloatingObject 스크립트를 가지고 있는지 확인
        FloatingObject floatingObject = collision.gameObject.GetComponent<FloatingObject>();
        if (floatingObject != null)
        {
            // 부유 효과를 활성화
            floatingObject.enabled = true;
        }
    }
}
