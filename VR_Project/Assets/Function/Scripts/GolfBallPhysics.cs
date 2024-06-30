using UnityEngine;

public class GolfBallPhysics : MonoBehaviour
{
    //public GameObject flag;
    public GameObject rCont;
    public GameObject lCont;

    // �� �����ϸ� ���� �߰�
    public float forceMultiplier = 1.25f;

    //private Vector3 ballPos;
    //private bool inHole;
    //private float holeRadius;
    //private Vector3 holePos;

    private void Start()
    {
        // ������ ��Ʈ�ѷ��� Hand ��ũ��Ʈ �߰�
        GameObject rightController = GameObject.Find("CustomHandRight");
        GolfHand rightHand = rightController.AddComponent<GolfHand>();
        rightHand.controller = OVRInput.Controller.RTouch;

        // �޼� ��Ʈ�ѷ��� Hand ��ũ��Ʈ �߰�
        GameObject leftController = GameObject.Find("CustomHandLeft");
        GolfHand leftHand = leftController.AddComponent<GolfHand>();
        leftHand.controller = OVRInput.Controller.LTouch;

        // GolfBallPhysics ��ũ��Ʈ�� ��Ʈ�ѷ� �Ҵ�
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
            Debug.Log("����");
            // �ӵ� ����
            GetComponent<Rigidbody>().velocity = other.GetComponent<GolfClubHead>().getVelocity() * forceMultiplier;
            // ��� ����
            //flag.SetActive(false);
            // ��Ʈ�ѷ� ����
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
