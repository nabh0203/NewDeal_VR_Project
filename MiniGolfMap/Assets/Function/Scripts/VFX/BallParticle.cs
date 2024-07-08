using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallParticle : MonoBehaviour
{
    public GameObject hitParticlePrefab;  // 쳤을 때 프리팹
    public GameObject goalParticlePrefab; // 골인 프리팹
    public Transform goalTransform;
    public float particleLifetime = 1f;

    private void OnCollisionEnter(Collision collision)
    {
     //GolfClub, Ball충돌
    
        //if (other.CompareTag("GolfClub")) 
        //{
        //    CreateParticle(hitParticlePrefab, transform.position);
        //}

        if (collision.gameObject.CompareTag("GolfClub"))
        {
            Debug.Log("공 이펙트 생성");
            GameObject particle = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particle, 1f);  // 1초 후에 파티클 제거
        }
    }
    
    // 콜리전 충돌 감지 (공과 골의 충돌)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal")) // 골 오브젝트에 "Goal" 태그를 붙여주세요
        {
            CreateParticle(goalParticlePrefab, goalTransform.position);
        }
    }

    void CreateParticle(GameObject particlePrefab, Vector3 position)
    {
        if (particlePrefab != null) // particlePrefab이 할당되었는지 확인
        {
            GameObject particle = Instantiate(particlePrefab, position, Quaternion.identity);
            Destroy(particle, particleLifetime);  // 설정된 수명 후에 파티클 제거
        }
    }
}
