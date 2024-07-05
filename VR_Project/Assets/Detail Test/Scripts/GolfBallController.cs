using UnityEngine;
using DG.Tweening;

public class GolfBallController : MonoBehaviour
{
    public Transform startPoint; // ������
    public Transform endPoint; // ����
    public Transform[] pathPoints; // ��θ� �����ϴ� ����Ʈ��
    public float baseDuration = 10f; // �⺻ �̵� �ð�
    private bool isMoving = false; // ���� �̵� ������ Ȯ���ϴ� �÷���
    private Rigidbody rb; // ���� Rigidbody ������Ʈ

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartPoint") && !isMoving) // Ʈ���ŵ� ������Ʈ�� StartPoint �±׸� ������ �ִ��� Ȯ��
        {
            MoveAlongPath();
        }
    }

    void MoveAlongPath()
    {
        isMoving = true; // �̵� ����
        Vector3[] path = new Vector3[pathPoints.Length + 2];
        path[0] = startPoint.position; // ������ �߰�
        for (int i = 0; i < pathPoints.Length; i++)
        {
            path[i + 1] = pathPoints[i].position;
        }

        path[pathPoints.Length + 1] = endPoint.position; // ���� �߰�

        // ���� �ӵ��� ����Ͽ� duration ���
        float speed = rb.velocity.magnitude; // �ּ� �ӵ� ����
        float duration = baseDuration / speed; // �ӵ��� �ݺ���Ͽ� �̵� �ð� ����

        rb.isKinematic = true;

        // ��θ� ���� �̵�
        transform.DOPath(path, 1f, PathType.CatmullRom)
           .SetEase(Ease.Linear) // �̵��� ��ȭ ���� ����
           .OnComplete(OnPathComplete) // ��� �̵� �Ϸ� �� ȣ��� �޼��� ����
           .SetLookAt(0.1f); // ��θ� ���� �̵��� �� ȸ�� ����

    }

    void OnPathComplete()
    {
        Debug.Log("Path completed!");
        isMoving = false; // �̵� �Ϸ�
        rb.isKinematic = false; // kinematic ��� �����Ͽ� ���� ������ �޵��� ��

        //rb.velocity = Vector3.zero; // ���� �ӵ� �ʱ�ȭ
        //rb.angularVelocity = Vector3.zero; // ���� ���ӵ� �ʱ�ȭ
            
        //rb.AddForce(Physics.gravity, ForceMode.Acceleration); // �߷¿� ���� �� ����
       
    }
}