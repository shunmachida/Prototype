using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletController : MonoBehaviour
{
    public GameObject Bullet;
    public static float x = 5000;
    public static int ballCoin = 1;     

    public void BulletCall()
    {
        GameObject ball = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity);
        //発砲音
        
        //火花
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(transform.forward * x);  
    }
}