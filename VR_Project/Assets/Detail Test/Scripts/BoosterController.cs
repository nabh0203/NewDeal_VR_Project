using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{
    //public float boostForce = 100f;
    public float forwardBoostForce = 10f; // Z πÊ«‚ ∫ŒΩ∫≈Õ¿« »˚
    public float leftwardBoostForce = 5f; // X πÊ«‚ ∫ŒΩ∫≈Õ¿« »˚ (øﬁ¬ ¿∏∑Œ »÷æÓ¡¸)
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                // playerRigidbody.AddForce(Vector3.forward * boostForce, ForceMode.Impulse);
                Vector3 boostDirection = new Vector3(-leftwardBoostForce, 0, forwardBoostForce);
                rigidbody.AddForce(boostDirection, ForceMode.Impulse);
            }
        }
    }
}
