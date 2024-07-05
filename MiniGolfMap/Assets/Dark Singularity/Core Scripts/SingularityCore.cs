//using UnityEngine;
//[RequireComponent(typeof(SphereCollider))]
//public class SingularityCore : MonoBehaviour
//{
//    //This script is responsible for what happens when the pullable objects reach the core
//    //by default, the game objects are simply turned off
//    //as this is much more performant than destroying the objects
//    void OnTriggerStay (Collider other) {
//        if(other.GetComponent<SingularityPullable>()){
//            other.gameObject.SetActive(false);
//        }
//    }

//    void Awake(){
//        if(GetComponent<SphereCollider>()){
//            GetComponent<SphereCollider>().isTrigger = true;
//        }
//    }
//}
//using UnityEngine;

//[RequireComponent(typeof(SphereCollider))]
//public class SingularityCore : MonoBehaviour
//{

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.GetComponent<BallController>()) //ball이 SingularityPullable 스크립트를 가지고 있으면 공 사라짐
//        {
//            other.GetComponent<BallController>().CountBall();
//        }
//    }

//    //코어의 트리거를 true로 바꿈 -> 이 공간 안에 들어오면 감지를 시작한다는거..?
//    void Awake()
//    {
//        if (GetComponent<SphereCollider>())
//        {
//            GetComponent<SphereCollider>().isTrigger = true;
//        }
//    }
//}

using UnityEngine;

public class SingularityCore : MonoBehaviour
{
    public GameObject golfBall;
    public GameObject goalPaticle;

    private int rotateBall = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolfBall")) //ball이 SingularityPullable 스크립트를 가지고 있으면 공 사라짐
        {
            CountBall();
        }
    }

    public void CountBall()
    {
        rotateBall++;
        if (rotateBall == 3)
        {
            
            golfBall.SetActive(false);
        }
        Instantiate(goalPaticle, transform.position, Quaternion.identity);
        Destroy(goalPaticle, 0.5f);
    }
}