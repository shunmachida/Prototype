using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public static int Time;
    public static int StartTime = 3;
    private IEnumerator StartTimeLoop;

    void Start()
    {
        //DontDestroyOnLoad (this);
        StartTimeLoop = StartTimeLoopFunc();
        StartCoroutine(StartTimeLoop);
        InvokeRepeating("TimeElapsed",0,1);
    }

    void TimeElapsed()
    {
        if(FGauge.F < FGauge.MaxF && StartTime == -1)
        {
            Time += 1;
            ClearTimeControl.ClearTime = Time;
        }
    }

    private IEnumerator StartTimeLoopFunc()
    {
        while (true)
        {
            StartTime -= 1;

            if (StartTime == -1)
            {
                yield break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}

