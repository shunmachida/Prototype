using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUCoin : MonoBehaviour
{
    private Transform myTransform;

    void Start()
    {   
        myTransform = this.transform;
        DPlayerStatus.UCoinCuont += 1;
        Debug.Log(DPlayerStatus.UCoinCuont);
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            myTransform.Rotate (0, 1, 0);
        }
        if(DPlayerStatus.UCoinStatus == false) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider Collider)
	{
		if (Collider.gameObject.tag == "Player")
        { 
            FGauge.F += 10f;
            DPlayerStatus.MaxUCoinCuont -= 1;
            //赤コイン拾う音(ピッチ*DPlayerStatus.MaxUCoinCuont)
            Debug.Log(DPlayerStatus.MaxUCoinCuont);
            Destroy(gameObject);
        }
    }

}
