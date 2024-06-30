using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBall : MonoBehaviour
{
    public GameObject GolfBall;
    public Transform spwan;
    public bool isBall;
    public FloatingObject_Two Float;

    // HapticFeedback 스크립트를 참조
    public HapticFeedback hapticFeedback;

    private void Start()
    {
        isBall = true;
        // HapticFeedback 스크립트를 현재 오브젝트에서 찾기
        hapticFeedback = GetComponent<HapticFeedback>();
        if (hapticFeedback == null)
        {
            Debug.LogError("HapticFeedback 스크립트를 찾을 수 없습니다.");
        }
    }

    private void Update()
    {
        // OVRInput을 사용하여 왼쪽 컨트롤러의 X 버튼을 감지합니다.
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            // X 버튼이 눌렸을 때 공을 지정한 위치로 이동시키고 속도를 0으로 설정합니다.
            ReturnToSpawn();
            if (hapticFeedback != null)
            {
                hapticFeedback.TriggerHapticFeedback(OVRInput.Controller.LTouch);
                hapticFeedback.TriggerHapticFeedback(OVRInput.Controller.RTouch);
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("GolfBall"))
    //    {
    //        Destroy(collision.gameObject);
    //        Instantiate(GolfBall, spwan.position, Quaternion.identity);
    //        Debug.Log("공 소환");
    //    }

    //    isBall = false;
    //    Debug.Log("공 소환 멈추기");
    //}

    private void ReturnToSpawn()
    {
        // 공을 지정한 위치로 이동시키고 속도와 각속도를 0으로 설정합니다.
        transform.position = spwan.position;
        transform.rotation = Quaternion.identity;
        isBall = true;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Debug.Log("공이 지정한 위치로 돌아왔습니다.");
    }
}
