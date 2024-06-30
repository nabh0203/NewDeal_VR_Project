using UnityEngine;
using OculusSampleFramework;

public class GolfFunction : MonoBehaviour
{
    public Transform clubHead; // ����ä�� ���
    public Rigidbody golfBall; // ���� ��
    public Transform vrController; // VR ��Ʈ�ѷ� (������)

    public float swingForceMultiplier = 10f; // ���� �� ���
    public float maxYForce = 5f; // ���� �ִ� Y�� ��

    private Vector3 lastPosition; // ���� �������� Ŭ�� ��ġ
    private Vector3 velocity; // Ŭ���� �ӵ�
    private Quaternion lastRotation; // ���� �������� Ŭ�� ȸ��
    private Vector3 angularVelocity; // Ŭ���� ���ӵ�

    void Start()
    {
        lastPosition = clubHead.position;
        lastRotation = clubHead.rotation;
    }

    void Update()
    {
        // VR ��Ʈ�ѷ��� ��ġ�� ȸ���� Ŭ���� �ݿ�
        clubHead.position = vrController.position;
        clubHead.rotation = vrController.rotation;

        // Ŭ���� �ӵ� ���
        velocity = (clubHead.position - lastPosition) / Time.deltaTime;
        lastPosition = clubHead.position;

        // Ŭ���� ���ӵ� ���
        angularVelocity = (clubHead.rotation.eulerAngles - lastRotation.eulerAngles) / Time.deltaTime;
        lastRotation = clubHead.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        // ����ä�� ���� ���� �浹�� ��
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            // Ŭ���� �ӵ��� ���ӵ��� ����Ͽ� ���� ���
            Vector3 force = velocity * swingForceMultiplier;
            Vector3 angularForce = angularVelocity * swingForceMultiplier * 0.1f; // ���ӵ��� ���� �߰� ��

            // ���� ������ �� �� ���
            Vector3 totalForce = force + angularForce;

            // Y�� ���� �ִ� ������ Ŭ����
            totalForce.y = Mathf.Clamp(totalForce.y, -Mathf.Infinity, maxYForce);

            // ���� ���� ����
            golfBall.AddForce(totalForce, ForceMode.Impulse);
        }
    }
}
