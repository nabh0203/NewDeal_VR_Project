using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                // Rigidbody 비활성화
                rigidbody.isKinematic = true;
            }
        }
    }
}
