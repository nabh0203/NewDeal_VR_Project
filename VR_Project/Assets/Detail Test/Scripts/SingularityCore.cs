using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SingularityCore : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallController>()) //ball이 SingularityPullable 스크립트를 가지고 있으면 공 사라짐
        {
            other.GetComponent<BallController>().CountBall();
        }
    }

    //코어의 트리거를 true로 바꿈 -> 이 공간 안에 들어오면 감지를 시작한다는거..?
    void Awake()
    {       
        if (GetComponent<SphereCollider>())
        {
            GetComponent<SphereCollider>().isTrigger = true; 
        }
    }
}