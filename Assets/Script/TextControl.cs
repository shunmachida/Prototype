using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextControl : MonoBehaviour
{
    public Text TimeText;
    public Text StartTimeText;
    public Text BulletText;
    public Text BombText;
    public Text ShieldText;
    public Text RecoveryText;

    void Start()
    {  
        BulletText.text = string.Format("{0}", BulletController.ballCoin);
        BombText.text = string.Format("{0}", BombControl.BombCoin);
        ShieldText.text = string.Format("{0}", ShieldControl.ShieldCoin);
        RecoveryText.text = string.Format("{0}", RecoveryControl.RecoveryCoin);
    }
    
    void Update () 
    {
        TimeText.text = string.Format("{0}", TimeControl.Time);

        if(TimeControl.StartTime == -1)
        {
            StartTimeText.text = string.Format("");
        }
        
        if(TimeControl.StartTime >= 0)
        {
            StartTimeText.text = string.Format("{0}", TimeControl.StartTime);
        }
    }
}
