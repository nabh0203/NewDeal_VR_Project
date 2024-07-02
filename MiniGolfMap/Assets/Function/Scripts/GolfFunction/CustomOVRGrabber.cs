using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LeftHand와 RightHand 태그를 Unity Editor에서 생성하고 각 손에 적용
public class CustomOVRGrabber : OVRGrabber
{
    protected override void Awake()
    {
        base.Awake();
        if (gameObject.name.Contains("LeftHand"))
        {
            gameObject.tag = "LeftHand";
        }
        else if (gameObject.name.Contains("RightHand"))
        {
            gameObject.tag = "RightHand";
        }
    }
}

