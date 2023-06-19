using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public GameObject Bomb;
    public static bool Bombr = false;
    public float x = 1000;
    public static int BombCoin = 10;

    void BombCall()
    {
        Bombr = true;
        //Invoke("BombRecast",CTcontrol.BombCT);        
        GameObject ball = (GameObject)Instantiate(Bomb, transform.position, Quaternion.identity);
        //ボムを投げえる音
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(transform.forward * x);
            
    }
    /* void BombRecast()
    {
        Bombr = false;
        CancelInvoke();
    } */
}

