using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClose : MonoBehaviour
{
    public GameObject uiimg;
    public GameObject Startuiimg;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("UI »ç¶óÁü");
            uiimg.SetActive(false);
            Invoke("closeUI", 0.5f);
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if(Startuiimg != null)
            {
                Debug.Log("UI »ç¶óÁü");
                Startuiimg.SetActive(false);
                Invoke("closeUI", 0.5f);
            }
        }
    }
}
