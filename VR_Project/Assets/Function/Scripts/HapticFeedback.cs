using System.Collections;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{
    [Range(0f, 2.5f)]
    public float duration = 0.5f; // 진동 지속 시간
    [Range(0f, 1f)]
    public float amplitude = 0.5f; // 진동 강도
    [Range(0f, 1f)]
    public float frequency = 1f; // 진동 빈도

    public int hapticCount = 1; // 진동 횟수

    public void TriggerHapticFeedback(OVRInput.Controller controller)
    {
        StartCoroutine(ProvideHapticFeedback(controller));
    }

    private IEnumerator ProvideHapticFeedback(OVRInput.Controller controller)
    {
        for (int i = 0; i < hapticCount; i++)
        {
            // 햅틱 피드백 시작
            OVRInput.SetControllerVibration(frequency, amplitude, controller);

            // 지정한 시간만큼 대기
            yield return new WaitForSeconds(duration);

            // 햅틱 피드백 중지
            OVRInput.SetControllerVibration(0, 0, controller);

            // 짧은 휴식 시간 (0.05초) 후 다시 진동 시작
            yield return new WaitForSeconds(0.01f);
        }
    }
}
