using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LeftHand�� RightHand �±׸� Unity Editor���� �����ϰ� �� �տ� ����
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

