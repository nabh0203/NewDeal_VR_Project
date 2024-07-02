using UnityEngine;

public class GolfBallPhysics : MonoBehaviour
{
    //public GameObject flag;
    public GameObject rCont;
    public GameObject lCont;

    // 힘 스케일링 변수 추가
    public float forceMultiplier = 1.25f;

    //private Vector3 ballPos;
    //private bool inHole;
    //private float holeRadius;
    //private Vector3 holePos;

    private void Start()
    {
        // 오른손 컨트롤러에 Hand 스크립트 추가
        GameObject rightController = GameObject.Find("CustomHandRight");
        GolfHand rightHand = rightController.AddComponent<GolfHand>();
        rightHand.controller = OVRInput.Controller.RTouch;

        // 왼손 컨트롤러에 Hand 스크립트 추가
        GameObject leftController = GameObject.Find("CustomHandLeft");
        GolfHand leftHand = leftController.AddComponent<GolfHand>();
        leftHand.controller = OVRInput.Controller.LTouch;

        // GolfBallPhysics 스크립트에 컨트롤러 할당
        GameObject golfBall = GameObject.Find("GolfBall 2");
        GolfBallPhysics golfBallPhysics = golfBall.GetComponent<GolfBallPhysics>();
        golfBallPhysics.rCont = rightController;
        golfBallPhysics.lCont = leftController;
    }

    //private void Update()
    //{
    //    // If past the edge of the hole
    //    if (Vector3.Distance(transform.position, holePos) < holeRadius)
    //    {
    //        // Turn off collider
    //        GetComponent<SphereCollider>().enabled = false;
    //        inHole = true;
    //    }
    //    // If kinematics are turned off
    //    if (inHole)
    //    {
    //        // Check if ball is still past edge of hole
    //        if (Vector3.Distance(transform.position, holePos) >= holeRadius)
    //        {
    //            inHole = false;
    //            // Reset collider
    //            GetComponent<SphereCollider>().enabled = true;
    //            // Reset ball position or handle it accordingly
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolfClub"))
        {
            Debug.Log("스윙");
            // 속도 전달
            GetComponent<Rigidbody>().velocity = other.GetComponent<GolfClubHead>().getVelocity() * forceMultiplier;
            // 깃발 제거
            //flag.SetActive(false);
            // 컨트롤러 진동
            if (rCont != null) rCont.GetComponent<GolfHand>().Vibrate(0.2f, 1.0f, 0.5f);
            if (lCont != null) lCont.GetComponent<GolfHand>().Vibrate(0.2f, 1.0f, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("border"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.Reflect(GetComponent<Rigidbody>().velocity, collision.contacts[0].normal) * 0.75F;
        }
    }

    public void ResetBallPosition(Vector3 position)
    {
        transform.position = position;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    //public void SetHoleData(Vector3 holePosition, float radius)
    //{
    //    holePos = holePosition;
    //    holeRadius = radius;
    //}
}
