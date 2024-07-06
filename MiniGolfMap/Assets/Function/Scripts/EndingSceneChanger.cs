using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneChanger : MonoBehaviour
{
    private float timer = 0.0f;
    public float waitTime = 40.0f; // 대기 시간 (초)

    void Update()
    {
        timer += Time.deltaTime; // 매 프레임마다 경과 시간 추가

        if (timer >= waitTime) // 40초가 지나면
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Start"); // "NextScene"을 로드
    }
}
