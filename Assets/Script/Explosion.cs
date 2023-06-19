using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    bool DamageLimit = false;
    void Start()
    {
        Invoke("Destroy", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider Collider)
    {
        if(Collider.gameObject.tag == "arm" && DamageLimit == false)
        {
            DamageLimit = true;
            FGauge.F += 10;
        }
    }
}
