using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletebullet : MonoBehaviour
{
    bool DamageLimit = false;

    void Start()
    {
        Invoke("Destroy", 5);
    }

    void Update()
    {
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider Collider)
	{        
		if (Collider.gameObject.tag == "arm" || Collider.gameObject.tag == "wall" || Collider.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if(Collider.gameObject.tag == "arm" && DamageLimit == false)
        {
            DamageLimit = true;
            FGauge.F += 1;
        }
    }
}
