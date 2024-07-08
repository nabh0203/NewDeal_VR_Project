using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVFX : MonoBehaviour
{
    public GameObject[] ballVFX;

    private GameObject currentVFX;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfClub"))
        {
            ChangeVFX(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            ChangeVFX(1);
        }
    }

    private void ChangeVFX(int index)
    {
        if (index < ballVFX.Length)
        {
            // ���� Ȱ��ȭ�� ����Ʈ�� ������ �ı��մϴ�.
            if (currentVFX != null)
            {
                Destroy(currentVFX);
            }

            // ���ο� ����Ʈ�� �����ϰ� currentVFX�� �����մϴ�.
            currentVFX = Instantiate(ballVFX[index], transform.position, Quaternion.identity);
            Destroy(currentVFX, 1f);
        }
        else
        {
            Debug.LogWarning("Not Index");
        }
    }
}
