using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGauge : MonoBehaviour
{
    [SerializeField]  AudioSource source1;
    [SerializeField]  AudioClip clip1;
    public static float MaxF = 100;
    public static float F = 0;
    int sa;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //フラストゲーション音(一回だけ鳴らす処理を入れる)
        /* if(sa +  == TimeControl.Time)
                {
                    d = false;
                    sa = TimeControl.Time;
                    source1.PlayOneShot(clip1);
                }
            if(Speed > 0.5 && d == false && TimeControl.Time > 1)
            {
                d = true;
                source1.PlayOneShot(clip1);
            }else if (Speed <= 0)
            {
                d = false;
                source1.Stop();
            } */
    }
}
