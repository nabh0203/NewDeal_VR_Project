using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] tutorialImages; // Ʃ�丮�� �̹��� �迭
    private int currentStep = 0; // ���� Ʃ�丮�� �ܰ�

    private void Start()
    {
        // �ʱ� �̹��� �迭�� �Ⱥ����� ��
        foreach (Image img in tutorialImages)
        {
            img.gameObject.SetActive(false);
        }

        // ù ��° Ʃ�丮�� �̹����� Ȱ��ȭ ��
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
        // ���� Ʃ�丮�� �̹����� ��Ȱ��ȭ
        if (currentStep < tutorialImages.Length)
        {
            tutorialImages[currentStep].gameObject.SetActive(false);
        }

        // ���� Ʃ�丮�� �̹����� �ִ� ��� Ȱ��ȭ
        currentStep++;
        if (currentStep < tutorialImages.Length)
        {
            tutorialImages[currentStep].gameObject.SetActive(true);
        }
    }
}
