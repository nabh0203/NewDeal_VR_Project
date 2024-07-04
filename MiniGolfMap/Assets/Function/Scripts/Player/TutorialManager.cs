using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] tutorialImages; // 튜토리얼 이미지 배열
    private int currentStep = 0; // 현재 튜토리얼 단계

    private void Start()
    {
        // 초기 이미지 배열이 안보여야 함
        foreach (Image img in tutorialImages)
        {
            img.gameObject.SetActive(false);
        }

        // 첫 번째 튜토리얼 이미지를 활성화 함
        if (tutorialImages.Length > 0)
        {
            tutorialImages[0].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            ShowNextTutorialStep();
        }
    }

    private void ShowNextTutorialStep()
    {
        // 현재 튜토리얼 이미지를 비활성화
        if (currentStep < tutorialImages.Length)
        {
            tutorialImages[currentStep].gameObject.SetActive(false);
        }

        // 다음 튜토리얼 이미지가 있는 경우 활성화
        currentStep++;
        if (currentStep < tutorialImages.Length)
        {
            tutorialImages[currentStep].gameObject.SetActive(true);
        }
    }
}
