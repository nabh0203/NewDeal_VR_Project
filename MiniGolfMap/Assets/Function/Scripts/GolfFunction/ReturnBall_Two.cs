using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBall_Two : MonoBehaviour
{
    public GameObject GolfBall;
    public Transform spwan;
    public bool isBall;
    public FloatingObject_Two Float;

    // HapticFeedback 스크립트를 참조
    public HapticFeedback hapticFeedback;

    public float duration = 1f; // 돌아가는데 걸리는 시간
    public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f); // 좀 천천히 이동하다가 속도가 붙는 커브선으로 이동

    private void Start()
    {
        isBall = true;
        // HapticFeedback 스크립트를 현재 오브젝트에서 찾기
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
            StartCoroutine(ReturnToSpawn());
            if (hapticFeedback != null)
            {
                hapticFeedback.TriggerHapticFeedback(OVRInput.Controller.LTouch);
                hapticFeedback.TriggerHapticFeedback(OVRInput.Controller.RTouch);
            }
        }
    }

    private IEnumerator ReturnToSpawn()
    {
        if (spwan == null) yield break;

        var beginTime = Time.time;
        var startPosition = transform.position;
        var targetPosition = spwan.position;

        while (true)
        {
            var t = (Time.time - beginTime) / duration;
            if (t >= 1f) break;

            t = curve.Evaluate(t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        transform.position = targetPosition;
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
