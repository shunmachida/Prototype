using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldstate : MonoBehaviour
{
    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "arm")
        {
            //シールドが砕ける音
            ShieldControl.relay = true;
            ShieldControl.Shieldstate = false;
            IconControl.b = true;
        }
    }
}
