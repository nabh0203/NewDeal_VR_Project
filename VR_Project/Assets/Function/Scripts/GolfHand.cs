using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHand : MonoBehaviour
{
    public OVRInput.Controller controller; // 컨트롤러를 설정하기 위한 변수




    // 진동을 실행하는 메서드
    public void Vibrate(float duration, float frequency, float amplitude)
    {
        StartCoroutine(VibrateCoroutine(duration, frequency, amplitude));
    }

    // 진동을 실행하는 코루틴
    private IEnumerator VibrateCoroutine(float duration, float frequency, float amplitude)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
