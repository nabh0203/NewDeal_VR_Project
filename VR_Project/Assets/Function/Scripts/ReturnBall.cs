using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnBall : MonoBehaviour
{
    public GameObject GolfBall;
    public Transform spwan;
    public bool isBall;
    private void Start() 
    {
        isBall = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            Destroy(collision.gameObject);
            Instantiate(GolfBall,spwan.position, Quaternion.identity);
            isBall = true;
            Debug.Log("�� ��ȯ");
        }

        isBall = false;
        Debug.Log("�� ��ȯ ���߱�");
    }
}

