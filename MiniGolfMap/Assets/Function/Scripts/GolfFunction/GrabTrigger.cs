using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrigger : MonoBehaviour
{
    public Rigidbody golfClub;
    private bool grabLeft;
    private bool grabRight;

    private void Start()
    {
        grabLeft = false;
        grabRight = false;
    }

    private void Update()
    {
        if (grabLeft && grabRight)
        {
            golfClub.isKinematic = false;
            golfClub.useGravity = true;
        }
        else
        {
            golfClub.isKinematic = true;
            golfClub.useGravity = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("HandL"))
        {
            grabLeft = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        }

        if (other.CompareTag("HandR"))
        {
            grabRight = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HandL"))
        {
            grabLeft = false;
        }

        if (other.CompareTag("HandR"))
        {
            grabRight = false;
        }
    }
}
