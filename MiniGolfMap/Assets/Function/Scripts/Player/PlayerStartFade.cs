using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartFade : MonoBehaviour
{
    public LoadSceneButton fadeBool;


    private void Start()
    {
        VR_Fade_NBH.instance.FadeOut();
    }

    private void Update()
    {
        //if(fadeBool.finish == true)
        //{
        //    VR_Fade_NBH.instance.FadeIn();
        //}

    }
}
