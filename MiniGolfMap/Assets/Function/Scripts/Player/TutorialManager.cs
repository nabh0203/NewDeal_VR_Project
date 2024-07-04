using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] tutorialImages;

    private bool tutorialone;
    private bool tutorialTwo;
    private bool tutorialThree;
    private bool tutorialfour;

    private void Start()
    {
        // 초기 이미지 배열이 안보여야 함
        foreach (Image img in tutorialImages)
        {
            img.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            // 버튼을 누르면 UI가 사라짐
            foreach (Image img in tutorialImages)
            {
                img.gameObject.SetActive(false);
            }
        }
    }
}
