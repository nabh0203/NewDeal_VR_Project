using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSFX : MonoBehaviour
{
    public AudioSource[] SFX;
    public AudioClip[] ballSFXs;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfClub"))
        {
            PlaySFX(0);
        }
    }

    public void returnBall()
    {
        PlaySFX(1);
    }

    private void PlaySFX(int index)
    {
        if (index < ballSFXs.Length)
        {
            foreach (var source in SFX)
            {
                source.clip = ballSFXs[index];
                source.Play();
            }
        }
        else
        {
            Debug.LogWarning("Index out of range");
        }
    }
}
