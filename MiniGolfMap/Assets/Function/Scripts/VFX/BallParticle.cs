using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallParticle : MonoBehaviour
{
    public GameObject hitParticlePrefab;  // ���� �� ������
    public GameObject goalParticlePrefab; // ���� ������
    public Transform goalTransform;
    public float particleLifetime = 1f;

    private void OnCollisionEnter(Collision collision)
    {
     //GolfClub, Ball�浹
    
        //if (other.CompareTag("GolfClub")) 
        //{
        //    CreateParticle(hitParticlePrefab, transform.position);
        //}

        if (collision.gameObject.CompareTag("GolfClub"))
        {
            Debug.Log("�� ����Ʈ ����");
            GameObject particle = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particle, 1f);  // 1�� �Ŀ� ��ƼŬ ����
        }
    }
    
    // �ݸ��� �浹 ���� (���� ���� �浹)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal")) // �� ������Ʈ�� "Goal" �±׸� �ٿ��ּ���
        {
            CreateParticle(goalParticlePrefab, goalTransform.position);
        }
    }

    void CreateParticle(GameObject particlePrefab, Vector3 position)
    {
        if (particlePrefab != null) // particlePrefab�� �Ҵ�Ǿ����� Ȯ��
        {
            GameObject particle = Instantiate(particlePrefab, position, Quaternion.identity);
            Destroy(particle, particleLifetime);  // ������ ���� �Ŀ� ��ƼŬ ����
        }
    }
}
