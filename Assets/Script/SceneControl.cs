using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneControl : MonoBehaviour
{
    public Image Phase;
    public static float a = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if(PlayersMoveControl.Stocklife == 0 && PlayersMoveControl.life == 0 && Phase != null)
        {
            Color color = Phase.GetComponent<Image>().color;
            color.a = a;
            a += 0.003f;
            CoinControl.Coin = 0;
            CameraControl.Speed = 0;
            PlayersMoveControl.UG = 0;
            PlayersMoveControl.moveSpeed = 0;
            PlayersMoveControl.DashSpeed = 0;
            PlayersMoveControl.moveSpeedNormalization = 0;
            ArmCall.ArmSpeed = 0;
            Phase.GetComponent<Image>().color = color;
        }
        
        if(PlayersMoveControl.Stocklife == 0 && PlayersMoveControl.life == 0 && a >= 1)
        {
            ChangeGameOverScene();
        }

        if(FGauge.F >= FGauge.MaxF && Phase != null)
        {
            Color color = Phase.GetComponent<Image>().color;
            color.a = a;
            a += 0.003f;
            CoinControl.Coin = 0;
            CameraControl.Speed = 0;
            PlayersMoveControl.UG = 0;
            PlayersMoveControl.moveSpeed = 0;
            PlayersMoveControl.DashSpeed = 0;
            PlayersMoveControl.moveSpeedNormalization = 0;
            ArmCall.ArmSpeed = 0;
            Phase.GetComponent<Image>().color = color;
        }

        if(FGauge.F >= FGauge.MaxF && a >= 1)
        {
            ChangeGameClerScene();
        }
    }

    public void ChangeGameClerScene()
    {
        SceneManager.LoadScene("GameClerScene");
    }

    public void ChangeGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ChangeGameScene() 
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ChangeSelect()
    {
        SceneManager.LoadScene("SelectionScene");
    }
}
