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
        // �ʱ� �̹��� �迭�� �Ⱥ����� ��
        foreach (Image img in tutorialImages)
        {
            img.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            // ��ư�� ������ UI�� �����
            foreach (Image img in tutorialImages)
            {
                img.gameObject.SetActive(false);
            }
        }
    }
}
