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
            // 현재 활성화된 이펙트가 있으면 파괴합니다.
            if (currentVFX != null)
            {
                Destroy(currentVFX);
            }

            // 새로운 이펙트를 생성하고 currentVFX에 저장합니다.
            currentVFX = Instantiate(ballVFX[index], transform.position, Quaternion.identity);
            Destroy(currentVFX, 1f);
        }
        else
        {
            Debug.LogWarning("Not Index");
        }
    }
}
