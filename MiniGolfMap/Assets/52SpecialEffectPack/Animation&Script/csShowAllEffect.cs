using UnityEngine;
using UnityEngine.UI;  // UI 네임스페이스를 추가합니다.
using System.Collections;

public class csShowAllEffect : MonoBehaviour
{
    public string[] EffectName;
    public Transform[] Effect;
    public Text Text1;  // GUIText 대신 Text를 사용합니다.
    public int i = 0;

    void Start()
    {
        Instantiate(Effect[i], new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        Text1.text = (i + 1) + ":" + EffectName[i];  // 괄호를 추가하여 의도된 순서대로 연산이 되도록 합니다.

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (i <= 0)
                i = 51;
            else
                i--;

            Instantiate(Effect[i], new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (i < 51)
                i++;
            else
                i = 0;

            Instantiate(Effect[i], new Vector3(0, 0, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(Effect[i], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
