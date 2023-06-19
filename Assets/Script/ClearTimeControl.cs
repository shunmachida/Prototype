using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClearTimeControl : MonoBehaviour
{
    //public static int ClearTime;
    public Text ClearText;
    public static int ClearTime;
    void Start()
    {
        ClearText.text = string.Format("タイム" + "{0}" + "秒", ClearTime);
    }

    void Update()
    {
        
    }
}
