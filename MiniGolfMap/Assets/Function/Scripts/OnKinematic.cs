using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKinematic : MonoBehaviour
{
    public GolfGrab_Two grabGolf;
    public Rigidbody golfRb;

    private void Start()
    {
        // 자식 오브젝트의 Rigidbody를 찾습니다.
        golfRb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (grabGolf != null)
        {
            if (grabGolf.isGrab == true)
            {
                golfRb.isKinematic = false;
                golfRb.useGravity = true;
            }
            else
            {
                golfRb.isKinematic = true;
                golfRb.useGravity = false;
            }
        }
    }
}
