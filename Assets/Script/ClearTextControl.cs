using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClearTextControl : MonoBehaviour
{
    public Text ClearText1;
    public Text ClearText2;
    public Text ClearText3;
    public Text ClearText4;
    public Text ClearText5;

    int i, j;
	int tmp = ClearTimeControl.ClearTime;
    public static int ClearTime1 = 66666;
    public static int ClearTime2 = 88888;
    public static int ClearTime3 = 99999;
    public static int ClearTime4 = 77777;
    public static int ClearTime5 = ClearTimeControl.ClearTime;
    public static int[] ScoreArray = {ClearTime1,ClearTime2,ClearTime3,ClearTime4,ClearTime5};
    
    void Start()
    {
        for (i = 0; i < 5; i++)
	    {
		    for (j = i + 1; j < 5; j++)
		    {
                if (ScoreArray[i] > ScoreArray[j] && ScoreArray[i] != 0 && ScoreArray[j] != 0)
                {
                    tmp = ScoreArray[i];
                    ScoreArray[i] = ScoreArray[j];
                    ScoreArray[j] = tmp;
                }
		    }
	    }
        for (i=0 ; i < 5 ; i++)
        {
            Debug.Log(i + "位" + ScoreArray[i]);
            if(i == 0)
            {
                ClearText1.text = string.Format("1位" + "{0}" + "秒", ScoreArray[i]);
            }
            else if(i == 1)
            {
                ClearText2.text = string.Format("2位" + "{0}" + "秒", ScoreArray[i]);
            }
            else if(i == 2)
            {
                ClearText3.text = string.Format("3位" + "{0}" + "秒", ScoreArray[i]);
            }
            else if(i == 3)
            {
                ClearText4.text = string.Format("4位" + "{0}" + "秒", ScoreArray[i]);
            }
            else if(i == 4)
            {
                ClearText5.text = string.Format("5位" + "{0}" + "秒", ScoreArray[i]);
            }
        }
    }
}
