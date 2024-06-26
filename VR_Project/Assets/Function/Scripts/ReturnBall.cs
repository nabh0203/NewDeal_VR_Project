using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnBall : MonoBehaviour
{
    //public Transform leftHandAnchor;
    public Transform rightHandAnchor;
    public float duration = 1f; // 돌아가는데 걸리는 시간
    public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f); // 천천히 이동하다가 속도가 붙는 커브
    public UnityEvent OnCompleted; // 타겟으로 돌아가는 이벤트 핸들러

    private Transform targetHand; // 현재 타겟이 되는 손
    public Quaternion targetRotation = Quaternion.identity; // 목표 회전값

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            targetHand = rightHandAnchor;
            Call();
        }       
    }
    public void Call()
    {
        if (!gameObject.activeInHierarchy || targetHand == null) return;

        StopAllCoroutines();
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
        if (targetHand == null) yield break;

        var beginTime = Time.time;
        var initialRotation = transform.rotation; // 현재 회전값 저장

        while (true)
        {
            var t = (Time.time - beginTime) / duration;
            if (t >= 1f) break;

            t = curve.Evaluate(t);

            // 위치 보간
            transform.position = Vector3.Lerp(transform.position, targetHand.position, t);
            // 회전 보간
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);

            yield return null;
        }

        transform.position = targetHand.position;
        transform.rotation = targetRotation; // 최종 회전값 설정

        OnCompleted?.Invoke();
    }
}

