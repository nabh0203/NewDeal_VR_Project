using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnBall : MonoBehaviour
{
    //public Transform leftHandAnchor;
    public Transform rightHandAnchor;
    public float duration = 1f; // ���ư��µ� �ɸ��� �ð�
    public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f); // õõ�� �̵��ϴٰ� �ӵ��� �ٴ� Ŀ��
    public UnityEvent OnCompleted; // Ÿ������ ���ư��� �̺�Ʈ �ڵ鷯

    private Transform targetHand; // ���� Ÿ���� �Ǵ� ��
    public Quaternion targetRotation = Quaternion.identity; // ��ǥ ȸ����

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
        var initialRotation = transform.rotation; // ���� ȸ���� ����

        while (true)
        {
            var t = (Time.time - beginTime) / duration;
            if (t >= 1f) break;

            t = curve.Evaluate(t);

            // ��ġ ����
            transform.position = Vector3.Lerp(transform.position, targetHand.position, t);
            // ȸ�� ����
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);

            yield return null;
        }

        transform.position = targetHand.position;
        transform.rotation = targetRotation; // ���� ȸ���� ����

        OnCompleted?.Invoke();
    }
}

