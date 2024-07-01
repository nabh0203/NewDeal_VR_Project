using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool pullable = true;
    private int n = 0;

    void Update()
    {
        MoveBall();
    }
    

    public void CountBall()
    {
        n++;
        if (n == 3)
        {
            gameObject.SetActive(false);
        }
    }
    public void MoveBall()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}