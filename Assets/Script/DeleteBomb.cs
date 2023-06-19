using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBomb : MonoBehaviour
{
    public GameObject ExplosionObject;          
    public static Vector3 ExplosionV;
    public Transform myTransform;
    bool DamageLimit = false;
    void Start()
    {
        myTransform = this.transform;
        Invoke("Destroy", 10);
    }

    void Update()
    {
        myTransform.Rotate (5, 0, 0);   
    }

    void Destroy()
    {
        Destroy(gameObject);
    }


    void OnTriggerStay(Collider Collider)
	{        
		if (Collider.gameObject.tag == "arm" || Collider.gameObject.tag == "wall" || Collider.gameObject.tag == "Ground")
        {
            ExplosionV = transform.position;
            Instantiate(ExplosionObject,ExplosionV, Quaternion.identity);
            //ボム爆発音

            //ボムの爆発エフェクト(再生0.5秒)
            Destroy(gameObject);
        }

        if(Collider.gameObject.tag == "arm" && DamageLimit == false)
        {
            DamageLimit = true;
            FGauge.F += 5;
        }
    }
}
