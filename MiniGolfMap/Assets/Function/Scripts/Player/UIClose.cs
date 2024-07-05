using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClose : MonoBehaviour
{
    public GameObject uiimg;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("UI »ç¶óÁü");
            uiimg.SetActive(false);
            Invoke("closeUI", 0.5f);
        }
    }
}
