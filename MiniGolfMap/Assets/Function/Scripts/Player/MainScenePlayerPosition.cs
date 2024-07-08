using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePlayerPosition : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = transform.localPosition;
        transform.localPosition = new Vector3(0.130999982f, 0.400000006f, 0.221698761f);
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}

    
