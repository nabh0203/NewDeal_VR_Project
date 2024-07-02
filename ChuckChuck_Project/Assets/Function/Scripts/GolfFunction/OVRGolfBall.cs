using UnityEngine;

public class OVRGolfBall : MonoBehaviour
{
    public static OVRGolfBall Instance; // 싱글톤 패턴을 위한 인스턴스

    private Rigidbody rb;

    void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    public void HitBall(Vector3 direction, float power)
    {
        // 공에 힘을 가함
        Vector3 force = direction * power;
        rb.AddForce(force, ForceMode.Impulse);

        // 디버그 로그로 힘을 출력
        Debug.Log($"공에 가해진 힘: {force}");
    }
}
