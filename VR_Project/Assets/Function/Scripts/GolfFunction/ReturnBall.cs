using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBall : MonoBehaviour
{
    public GameObject GolfBall;
    public Transform spwan;
    public bool isBall;
    public FloatingObject_Two Float;

    // HapticFeedback ��ũ��Ʈ�� ����
    public HapticFeedback hapticFeedback;

    private void Start()
    {
        isBall = true;
        // HapticFeedback ��ũ��Ʈ�� ���� ������Ʈ���� ã��
        hapticFeedback = GetComponent<HapticFeedback>();
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
    //        Debug.Log("�� ��ȯ");
    //    }

    //    isBall = false;
    //    Debug.Log("�� ��ȯ ���߱�");
    //}

    private void ReturnToSpawn()
    {
        // ���� ������ ��ġ�� �̵���Ű�� �ӵ��� ���ӵ��� 0���� �����մϴ�.
        transform.position = spwan.position;
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
