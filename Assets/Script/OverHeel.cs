using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverHeel : MonoBehaviour
{
    public Slider OverHP;
    void Start()
    {
        OverHP.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        OverHP.value = (float)BPlayerStatus.OverHeel / (float)BPlayerStatus.MaxOverHeel;
    }
}
