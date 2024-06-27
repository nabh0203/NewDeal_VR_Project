using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnBall : MonoBehaviour
{
    public GameObject GolfBall;
    public Transform spwan;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            Destroy(collision.gameObject);
            Instantiate(GolfBall,spwan.position, Quaternion.identity);
            Debug.Log("°ø ¼ÒÈ¯");
        }
    }
}

