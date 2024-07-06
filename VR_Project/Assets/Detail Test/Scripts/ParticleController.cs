using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject hitParticlePrefab;  // ���� �� ������
    public GameObject goalParticlePrefab; // ���� ������
    public Transform goalTransform;       
    public float particleLifetime = 1f;   
    
    private void OnTriggerEnter(Collider other) //GolfClub, Ball�浹
    {
        //if (other.CompareTag("GolfClub")) 
        //{
        //    CreateParticle(hitParticlePrefab, transform.position);
        //}

        if (other.CompareTag("GolfClub"))         {
            GameObject particle = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particle, 1f);  // 1�� �Ŀ� ��ƼŬ ����
        }
    }

    // �ݸ��� �浹 ���� (���� ���� �浹)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal")) // �� ������Ʈ�� "Goal" �±׸� �ٿ��ּ���
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

