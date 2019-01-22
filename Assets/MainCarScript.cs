using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarScript : MonoBehaviour
{

    public DrivingGameController dgc;

    private void OnTriggerEnter(Collider other)
    {
        EnemyCarScript ecs = other.GetComponent<EnemyCarScript>();
        if (ecs && dgc)
        {
            dgc.Crash();
        }
    }

    public void CrashFinished()
    {
        dgc.ShowLeaderboards();
    }
}
