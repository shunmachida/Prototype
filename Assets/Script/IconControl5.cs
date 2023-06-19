using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconControl5 : MonoBehaviour
{
    public Image IconCT;
    public Image IconCoin;
    //private IEnumerator testLoop;
    public static bool a = false;
    public static bool b = false;
    public static bool c = false;
    public static float s;
    public static float d;
    void Start()
    {
        //testLoop = TestLoopFunc();
        IconCT.fillAmount = 0;
        IconCoin.fillAmount = 0;
    }

    void Update()
    {
        IconCoin.fillAmount = (float)CoinControl.Coin / (float)PlayersMoveControl.AbilityCoin;
        if(b == true)
        {
            if(a == false)
            {   
                a = true;
                s = CTcontrol.AbilityCT;
                d = 0;
                IconCT.fillAmount = 0;
                //StartCoroutine(testLoop);
                InvokeRepeating("LocalTime",0,1);
            }
            IconCT.fillAmount = d / s;
        }
        if(c == true)
        {
            IconCoin.fillAmount = 0;
        }
    }

    void LocalTime()
    {
        if(d != s)
        {
            d += 1;
            Debug.Log(d);
        }
        else
        {
            a = false;
            CancelInvoke();
        }
    }
}
