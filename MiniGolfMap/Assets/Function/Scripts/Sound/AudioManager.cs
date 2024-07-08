using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startClip;
    public AudioClip startButtonClickClip;
    //public AudioClip hitBallClip;
    //public AudioClip dropBallClip;
    //public AudioClip goalBallClip;
    public AudioClip stage1Clip;
    public AudioClip stage2Clip;
    public AudioClip stage3Clip;
    public AudioClip endingClip;


    public void OnStartGame()
    {
        PlayAudioClip(startClip);
        Debug.Log("À½¾Ç Àç»ý");
    }

    public void OnStartButtonClick()
    {
        PlayAudioClip(startButtonClickClip);
    }

    //public void OnBallHit()
    //{
    //    PlayAudioClip(hitBallClip);
    //}

    //public void OnBallDrop()
    //{
    //    PlayAudioClip(dropBallClip);
    //}

    //public void OnGoal()
    //{
    //    PlayAudioClip(goalBallClip);
    //}

    public void PlayStage1Music()
    {
        PlayAudioClip(stage1Clip);
    }

    public void PlayStage2Music()
    {
        PlayAudioClip(stage2Clip);
    }

    public void PlayStage3Music()
    {
        PlayAudioClip(stage3Clip);
    }

    public void PlayEndingMusic()
    {
        PlayAudioClip(endingClip);
    }

    public  void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
