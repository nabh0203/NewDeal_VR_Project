using System.Collections;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{
    [Range(0f, 2.5f)]
    public float duration = 0.5f; // ���� ���� �ð�
    [Range(0f, 1f)]
    public float amplitude = 0.5f; // ���� ����
    [Range(0f, 1f)]
    public float frequency = 1f; // ���� ��

    public int hapticCount = 1; // ���� Ƚ��

    public void TriggerHapticFeedback(OVRInput.Controller controller)
    {
        StartCoroutine(ProvideHapticFeedback(controller));
    }

    private IEnumerator ProvideHapticFeedback(OVRInput.Controller controller)
    {
        for (int i = 0; i < hapticCount; i++)
        {
            // ��ƽ �ǵ�� ����
            OVRInput.SetControllerVibration(frequency, amplitude, controller);

            // ������ �ð���ŭ ���
            yield return new WaitForSeconds(duration);

            // ��ƽ �ǵ�� ����
            OVRInput.SetControllerVibration(0, 0, controller);

            // ª�� �޽� �ð� (0.05��) �� �ٽ� ���� ����
            yield return new WaitForSeconds(0.01f);
        }
    }
}
