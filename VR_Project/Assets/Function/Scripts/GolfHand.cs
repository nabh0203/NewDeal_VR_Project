using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHand : MonoBehaviour
{
    public OVRInput.Controller controller; // ��Ʈ�ѷ��� �����ϱ� ���� ����




    // ������ �����ϴ� �޼���
    public void Vibrate(float duration, float frequency, float amplitude)
    {
        StartCoroutine(VibrateCoroutine(duration, frequency, amplitude));
    }

    // ������ �����ϴ� �ڷ�ƾ
    private IEnumerator VibrateCoroutine(float duration, float frequency, float amplitude)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
