using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public Transform wormholeExit;
    public float absorptionSpeed = 5f;
    private bool isAbsorbing = false;
    private GameObject ball;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ball = other.gameObject;
            isAbsorbing = true;
        }
    }

    void Update()
    {
        if (isAbsorbing && ball != null)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, transform.position, absorptionSpeed * Time.deltaTime);

            if (Vector3.Distance(ball.transform.position, transform.position) < 0.1f)
            {
                ball.transform.position = wormholeExit.position;
                isAbsorbing = false;
                ball = null;
            }
        }
    }
}