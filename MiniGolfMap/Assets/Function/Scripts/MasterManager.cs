using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviour
{
    public GoalSpot master;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            master.MoveToTargetPosition();
        }
    }
}
