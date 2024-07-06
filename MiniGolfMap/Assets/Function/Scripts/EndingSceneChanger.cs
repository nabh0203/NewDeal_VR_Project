using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneChanger : MonoBehaviour
{
    private float timer = 0.0f;
    public float waitTime = 40.0f; // ��� �ð� (��)

    void Update()
    {
        timer += Time.deltaTime; // �� �����Ӹ��� ��� �ð� �߰�

        if (timer >= waitTime) // 40�ʰ� ������
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Start"); // "NextScene"�� �ε�
    }
}
