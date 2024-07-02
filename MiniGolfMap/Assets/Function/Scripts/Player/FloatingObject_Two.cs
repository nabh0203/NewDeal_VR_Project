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
    public Transform startPosition;

    public ReturnBall reBall;
    public HapticFeedback hapticFeedback;

    void Start()
    {
        // 오브젝트의 시작 위치를 startPosition에서 가져옵니다.
        transform.position = startPosition.position;

        if (hapticFeedback == null)
        {
            Debug.LogError("HapticFeedback 스크립트를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        if (reBall.isBall == true)
        {
            Gravity();
            //enabled = true;
            Debug.Log("부유 시작");
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
            // 부유 시작
            //enabled = false;
            reBall.isBall = false;
            Debug.Log("충돌");
        }
    }

    private void Gravity()
    {
        // 부유하는 애니메이션을 계산
        float newY = startPosition.position.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.position.x, newY, startPosition.position.z);
    }
}
