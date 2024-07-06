using UnityEngine;

public class GoalParticle : MonoBehaviour
{
    public Transform goalTransform; // 골 위치
    public GameObject goalParticlePrefab; // 골에 들어갔을 때 생성되는 파티클 프리팹
    public float particleLifetime = 0.5f; // 파티클 수명

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