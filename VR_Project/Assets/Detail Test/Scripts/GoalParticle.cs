using UnityEngine;

public class GoalParticle : MonoBehaviour
{
    public Transform goalTransform; // �� ��ġ
    public GameObject goalParticlePrefab; // �� ���� �� �����Ǵ� ��ƼŬ ������
    public float particleLifetime = 0.5f; // ��ƼŬ ����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CreateParticle(goalParticlePrefab, goalTransform.position);
        }
    }

    void CreateParticle(GameObject particlePrefab, Vector3 position)
    {
        GameObject particle = Instantiate(particlePrefab, position, Quaternion.identity);
        Destroy(particle, particleLifetime);
    }
}