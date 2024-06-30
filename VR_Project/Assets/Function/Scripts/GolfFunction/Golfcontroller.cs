using UnityEngine;

public class GolfController : MonoBehaviour
{
    public Rigidbody golfBall; // �������� Rigidbody

    private Vector3 lastPosition; // ����ä�� ���� ������ ��ġ
    private Vector3 velocity; // ����ä�� �ӵ�

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // ����ä�� �ӵ��� ����մϴ�.
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // ����ä�� ���� �浹���� ��
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            // ���� �ӵ��� �����մϴ�.
            Vector3 hitDirection = collision.contacts[0].point - transform.position;
            hitDirection = hitDirection.normalized;

            // ���� ���� ���մϴ�.
            golfBall.velocity = velocity.magnitude * hitDirection;
        }
    }
}
