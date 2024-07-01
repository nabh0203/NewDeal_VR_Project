using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Singularity : MonoBehaviour  // 근처의 오브젝트를 끌어당기는 메인 스크립트
{
    [SerializeField] private float GRAVITY_PULL = 100f; 
    static float m_GravityRadius = 1f; //중력 작용 반경

    void Awake()
    {   
        // SphereCollider가 존재하면 isTrigger를 true로 설정
        if (GetComponent<SphereCollider>())
        {
            GetComponent<SphereCollider>().isTrigger = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball")) //감지된 것의 태그가 ball이면
        {
            // 중력 강도를 계산
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            // 중력 당김의 힘을 적용
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
            //attachedRigidbody : 콜라이더가 부착된 rigidbody
        }
    }
}