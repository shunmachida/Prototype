using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconControl : MonoBehaviour
{
    public Image IconCT;
    public Image IconCoin;
    //private IEnumerator testLoop;
    public static bool a = false;
    public static bool b = false;
    public static float s;
    public static float d;
    void Start()
    {
        //testLoop = TestLoopFunc();
        IconCT.fillAmount = 0;
        IconCoin.fillAmount = 1;
    }

    void Update()
    {
        
        IconCoin.fillAmount = (float)CoinControl.Coin / (float)ShieldControl.ShieldCoin;
        if(b == true)
        {
            if(a == false)
            {   
                a = true;
                s = CTcontrol.ShieldCT;
                d = 0;
                IconCT.fillAmount = 0;
                //StartCoroutine(testLoop);
                InvokeRepeating("LocalTime",0,1);
            }
            IconCT.fillAmount = d / s;
        }
        if(ShieldControl.Shieldstate == true)
        {
            IconCoin.fillAmount = 0;
        }
        
    }


    void LocalTime()
    {
        if(d != s)
        {
            d += 1;
            
        }
        else
        {
            a = false;
            CancelInvoke();
        }
    }
}