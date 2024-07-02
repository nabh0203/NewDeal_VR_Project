using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBall_Two : MonoBehaviour
{
    public GameObject GolfBall;
    public Transform spwan;
    public bool isBall;
    public FloatingObject_Two Float;

    // HapticFeedback ��ũ��Ʈ�� ����
    public HapticFeedback hapticFeedback;

    public float duration = 1f; // ���ư��µ� �ɸ��� �ð�
    public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f); // �� õõ�� �̵��ϴٰ� �ӵ��� �ٴ� Ŀ�꼱���� �̵�

    private void Start()
    {
        isBall = true;
        // HapticFeedback ��ũ��Ʈ�� ���� ������Ʈ���� ã��
        if (hapticFeedback == null)
        {
            Debug.LogError("HapticFeedback ��ũ��Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    private void Update()
    {
        // OVRInput�� ����Ͽ� ���� ��Ʈ�ѷ��� X ��ư�� �����մϴ�.
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            // X ��ư�� ������ �� ���� ������ ��ġ�� �̵���Ű�� �ӵ��� 0���� �����մϴ�.
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

        Debug.Log("���� ������ ��ġ�� ���ƿԽ��ϴ�.");
    }
}
