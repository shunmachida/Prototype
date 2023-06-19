using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCoin : MonoBehaviour
{
    private Transform myTransform;

    void Start()
    {
        myTransform = this.transform;
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            myTransform.Rotate (0, 1, 0);
        }
    }
    /* void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            if(CoinControl.Coin < CoinControl.MaxCoin)
            {
                CoinControl.Coin += CoinControl.GetCoin;
            }
            else
            {
                CoinControl.Coin = CoinControl.MaxCoin;
            }
                Debug.Log("コインの枚数: " + CoinControl.Coin);
            
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
            Debug.Log("コインが破壊されましたc");
        }
    } */

    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "Player" || Collider.gameObject.tag == "Coinfield" || Collider.gameObject.tag == "Bullet")
        {
            if(CoinControl.Coin < CoinControl.MaxCoin)
            {
                CoinControl.Coin += CoinControl.GetCoin;
                //コイン拾った時音
                
            }
            else
            {
                CoinControl.Coin = CoinControl.MaxCoin;
            }
                Debug.Log("コインの枚数: " + CoinControl.Coin);
        
            Destroy(gameObject);
        }

        if(Collider.gameObject.tag == "Shield" || Collider.gameObject.tag == "Explosion")
        {
            Destroy(gameObject);
            Debug.Log("コインが破壊されましたC");
        }
    }

   /*  void OnDestroy()
    {
        if(CoinControl.Coin < CoinControl.MaxCoin)
        {
            CoinControl.Coin += CoinControl.GetCoin;
        }
        else
        {
            CoinControl.Coin = CoinControl.MaxCoin;
        }
        Debug.Log("コインの枚数: " + CoinControl.Coin);
    } */
}
