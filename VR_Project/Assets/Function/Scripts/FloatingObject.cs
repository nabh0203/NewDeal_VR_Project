/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // �����ϴ� �ӵ�
    public float floatSpeed = 1.0f;
    // �����ϴ� ����
    public float floatHeight = 0.5f;
    // ���� ��ġ�� �����ϱ� ���� ����
    private Vector3 startPosition;

    public ReturnBall Reball;

    void Start()
    {
        // ������Ʈ�� ���� ��ġ�� ����
        startPosition = transform.position;
    }

    void Update()
    {
        if(Reball.isBall == false )
        {
            Debug.Log("���� ����");
            Gravity();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfClub"))
        {
            // ���� ����
            enabled = false;
            Debug.Log("�浹");
        }
    }

    private void Gravity()
    {
        // �����ϴ� �ִϸ��̼��� ���
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

}
*/


using UnityEngine;
using DG.Tweening;

public class FloatingObject : MonoBehaviour
{
    public float floatHeight = 1f; // �����ϴ� ����
    public float floatDuration = 2f; // �����ϴ� �ð�

    private void Start()
    {
        // ������Ʈ�� �����ϰ� ����� Ʈ�� �ִϸ��̼� ����
        transform.DOMoveY(transform.localPosition.y + floatHeight, floatDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}

