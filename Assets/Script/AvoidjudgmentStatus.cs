using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidjudgmentStatus : MonoBehaviour
{
    bool RecastStatus = false;
    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "arm" && RecastStatus == false)
        {
            RecastStatus = true;
            FGauge.F += 10;
            Debug.Log("F:" + FGauge.F);
            Invoke("Recast", CTcontrol.AvoidjudCT);
        }
    }
    void Recast ()
    {
        RecastStatus = false;
        CancelInvoke();
    }
}
