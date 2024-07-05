using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Singularity : MonoBehaviour  // 근처의 오브젝트를 끌어당기는 메인 스크립트
{
    [SerializeField] private float GRAVITY_PULL = 200f; 
    static float m_GravityRadius = 1f; //중력 작용 반경
    [SerializeField] private float Y_AXIS_GRAVITY_MULTIPLIER = 1.5f; // Y축 중력 강도 배수

    void Awake()
    {
        //// SphereCollider가 존재하면 isTrigger를 true로 설정
        //if (GetComponent<SphereCollider>())
        //{
        //    GetComponent<SphereCollider>().isTrigger = true;
        //}


        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider)
        {
            collider.isTrigger = true;
            collider.radius = m_GravityRadius; // 중력 작용 반경 설정
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball")) //감지된 것의 태그가 ball이면
        {
            //// 중력 강도를 계산
            //float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            //// 중력 당김의 힘을 적용
            //other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);

            Vector3 direction = (transform.position - other.transform.position).normalized; // 중심으로 당기는 방향
            float distance = Vector3.Distance(transform.position, other.transform.position); // 거리 계산
            float gravityIntensity = 1f - (distance / m_GravityRadius); // 거리 비례 중력 강도 계산

            //// 중력 당김의 힘을 적용
            //other.attachedRigidbody.AddForce(direction * gravityIntensity * GRAVITY_PULL * other.attachedRigidbody.mass * Time.deltaTime);

            // 중력 당김의 힘을 적용
            Vector3 force = direction * gravityIntensity * GRAVITY_PULL * other.attachedRigidbody.mass * Time.deltaTime;

            // Y축 방향으로 힘을 더 강하게 적용
            force.y *= Y_AXIS_GRAVITY_MULTIPLIER;

            other.attachedRigidbody.AddForce(force);

        }


    }
}