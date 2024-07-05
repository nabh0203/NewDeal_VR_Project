//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallSFX : MonoBehaviour
//{
//    public AudioSource[] SFX;
//    public AudioClip[] ballSFXs;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Goal"))
//        {
//            ChangeSFX(0);
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("GolfClub"))
//        {
//            ChangeSFX(1);
//        }
//    }


//    private void ChangeSFX(int index)
//    {
//        if (index < SFX.Length && index < ballSFXs.Length)
//        {
//            for (int i = 0; i < SFX.Length; i++)
//            {
//                SFX[i].clip = ballSFXs[index];
//                SFX[i].Play();
//            }
//        }
//        else
//        {
//            Debug.LogWarning("Not Index");
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSFX : MonoBehaviour
{
    public AudioSource[] SFX;
    public AudioClip[] ballSFXs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            ChangeSFX(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfClub"))
        {
            ChangeSFX(1);
        }
    }

    private void ChangeSFX(int index)
    {
        if (index < SFX.Length && index < ballSFXs.Length)
        {
            for (int i = 0; i < SFX.Length; i++)
            {
                SFX[i].PlayOneShot(ballSFXs[index]);
            }
        }
        else
        {
            Debug.LogWarning("Index out of range");
        }
    }
}

