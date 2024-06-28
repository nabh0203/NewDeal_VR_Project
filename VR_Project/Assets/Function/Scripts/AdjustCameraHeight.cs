using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCameraHeight : MonoBehaviour
{
    // 사용자 키를 입력 받기 위한 변수
    public float userHeight = 1.8f; // 기본 키는 1.8미터로 설정

    // 카메라 리그의 Transform을 참조하기 위한 변수
    public Transform cameraRig;

    void Start()
    {
        // cameraRig이 설정되지 않았다면, OVRCameraRig를 찾아서 설정
        if (cameraRig == null)
        {
            OVRCameraRig rig = FindObjectOfType<OVRCameraRig>();
            if (rig != null)
            {
                cameraRig = rig.transform;
            }
            else
            {
                Debug.LogError("OVRCameraRig not found in the scene.");
                return;
            }
        }

        // 사용자 키 높이에 따라 카메라 리그 높이 조정
        AdjustHeight();
    }

    // 사용자 키 높이에 따라 카메라 리그 높이를 조정하는 메서드
    void AdjustHeight()
    {
        if (cameraRig != null)
        {
            // 카메라 리그의 현재 위치를 가져온 후, y축 높이를 사용자 키로 설정
            Vector3 newPosition = cameraRig.position;
            newPosition.y = userHeight;
            cameraRig.position = newPosition;
        }
    }

    // Inspector에서 실시간으로 사용자 키를 조정할 수 있도록 업데이트 메서드에 포함
    void Update()
    {
        AdjustHeight();
    }
}
