using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPlayerStatus : MonoBehaviour
{
    public static float Maxlife = 3;
    public static double MaxStamina = 10;
    public static float SPlayermoveSpeed = 15;
    public static float SDashSpeed = SPlayermoveSpeed * 2;
    float SPlayerjumpPower = 9;
    public static int MaxCoin = 50;
    public static float MaxUG = 100;
    public static bool AbilityStatus = false;
    public static bool AbilityCT = false;
    public static bool UrutoStatus = false;
    public static bool UrutoCT = false;
    public static bool AvoidjudgmentStatus = false;
    public static int AbilityCoin = 10;
    public GameObject Coinfield;
    public GameObject Bulletcall;
    public GameObject Bombcall;
    public GameObject Avoidjudgment; 
    public Material DamageMaterial;
    public Material NormalMaterial;
    public Text AbilityText;
    public Text UGText;
    public static bool a = false;
    public static bool b = false;
    public static bool d = false;

    void Start()
    {
        CoinControl.GetCoin = 5;
        PlayersMoveControl.AbilityCoin = AbilityCoin;
        PlayersMoveControl.DashSpeed = SDashSpeed;
        PlayersMoveControl.MaxUG = MaxUG;
        PlayersMoveControl.MaxStamina = MaxStamina;
        PlayersMoveControl.Maxlife = Maxlife;
        CoinControl.MaxCoin = MaxCoin;
        PlayersMoveControl.moveSpeed = SPlayermoveSpeed;
        PlayersMoveControl.jumpPower = SPlayerjumpPower;
        PlayersMoveControl.DamageMaterial = DamageMaterial;
        PlayersMoveControl.NormalMaterial = NormalMaterial;
        Debug.Log("HP:" + PlayersMoveControl.life);
        AbilityText.text = string.Format("{0}", AbilityCoin);
        UGText.text = string.Format("{0}", PlayersMoveControl.MaxUG);
        Avoidjudgment.SetActive(AvoidjudgmentStatus);
        Coinfield.SetActive(AbilityStatus);
    }

    void Update()
    {
        Avoidjudgment.SetActive(AvoidjudgmentStatus);
        Coinfield.SetActive(AbilityStatus);
        
        if(CTcontrol.BombStockTime < TimeControl.Time)
        {
            BombControl.Bombr = false;
        }

        if(CTcontrol.ShieldStockTime2 < TimeControl.Time)
        {
            IconControl.b = true; 
            ShieldControl.Shieldstate = false;
        }
        if(CTcontrol.ShieldStockTime < TimeControl.Time)
        {
            ShieldControl.Shieldr = false;
            IconControl.b = false;
        }

        if(CTcontrol.RecoveryStockTime < TimeControl.Time)
        {
            PlayersMoveControl.RecoveryStatus = false;
        }

        if(CTcontrol.AbilityStockTime2 < TimeControl.Time)
        {
            //バリバリ音消す
            
            IconControl5.b = true;  
            AbilityStatus = false;
            IconControl5.c = false; 
        }
        if(CTcontrol.AbilityStockTime < TimeControl.Time)
        {
            IconControl5.b = false; 
            AbilityCT = false;
        }

         if(CTcontrol.UrutoStockTime2 < TimeControl.Time)
        {
            //ウルトBGM(stop)

            //ゲームBGM(start)

            IconControl6.b = true;  
            AvoidjudgmentStatus = false;
            IconControl6.c = false; 
            PlayersMoveControl.StaminaConsumption = 0.01f;
            PlayersMoveControl.StaminaConsumptionj = 2;
            PlayersMoveControl.SPlayerUGmov = false;
            PlayersMoveControl.moveSpeed = SPlayermoveSpeed;
        }
        if(CTcontrol.UrutoStockTime < TimeControl.Time)
        {
            IconControl6.b = false;
            UrutoCT = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha1) && CoinControl.Coin >= BulletController.ballCoin && Time.timeScale == 1 && a == false)
        {
            CoinControl.Coin -= BulletController.ballCoin;
            Debug.Log("コインの枚数: " + CoinControl.Coin);
            if (PlayersMoveControl.UG < PlayersMoveControl.MaxUG)
                {
                    PlayersMoveControl.UG += BulletController.ballCoin;
                    Debug.Log("Ug:" + PlayersMoveControl.UG);
                }
                else
                {
                    PlayersMoveControl.UG = PlayersMoveControl.MaxUG;
                    Debug.Log("Ug:" + PlayersMoveControl.UG);
                }
            Bulletcall.SendMessage("BulletCall");
        }
        //Debug.Log(CTcontrol.BombStockTime + " <=" + TimeControl.Time);
        if(Input.GetKeyDown(KeyCode.Alpha2) && CoinControl.Coin >= BombControl.BombCoin && BombControl.Bombr == false && Time.timeScale == 1 && a == false)
        {
            CoinControl.Coin -= BombControl.BombCoin;
            CTcontrol.BombStockTime = TimeControl.Time + CTcontrol.BombCT;
            IconControl3.b = true;
            
            Debug.Log("コインの枚数: " + CoinControl.Coin);
            if (PlayersMoveControl.UG < PlayersMoveControl.MaxUG)
                {
                    PlayersMoveControl.UG += BombControl.BombCoin;
                    Debug.Log("Ug:" + PlayersMoveControl.UG);
                }
                else
                {
                    PlayersMoveControl.UG = PlayersMoveControl.MaxUG;
                    Debug.Log("Ug:" + PlayersMoveControl.UG);
                }
            Bombcall.SendMessage("BombCall");
        }
        if(Input.GetKey(KeyCode.Alpha3) && CoinControl.Coin >= ShieldControl.ShieldCoin && ShieldControl.Shieldr == false && Time.timeScale == 1)
        {

            CoinControl.Coin -= ShieldControl.ShieldCoin;
            CTcontrol.ShieldStockTime2 = TimeControl.Time + ShieldControl.t;
            CTcontrol.ShieldStockTime = CTcontrol.ShieldStockTime2 + CTcontrol.ShieldCT;
            Debug.Log("コインの枚数: " + CoinControl.Coin);
            Debug.Log("CT" + CTcontrol.ShieldStockTime);
            Debug.Log("効果終了時間"+ CTcontrol.ShieldStockTime2);
            ShieldControl.Shieldstate = true;
            ShieldControl.Shieldr = true;

            if (PlayersMoveControl.UG < PlayersMoveControl.MaxUG)
            {
                PlayersMoveControl.UG += ShieldControl.ShieldCoin;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
            }
            else
            {
                PlayersMoveControl.UG = PlayersMoveControl.MaxUG;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && CoinControl.Coin >= RecoveryControl.RecoveryCoin && PlayersMoveControl.Maxlife > PlayersMoveControl.life && PlayersMoveControl.RecoveryStatus == false && Time.timeScale == 1)
            {
                PlayersMoveControl.RecoveryStatus = true;
                CTcontrol.RecoveryStockTime = TimeControl.Time + CTcontrol.RecoveryCT;
                CoinControl.Coin -= RecoveryControl.RecoveryCoin;
                IconControl4.b = true;
                Debug.Log("コインの枚数: " + CoinControl.Coin);
            if (PlayersMoveControl.UG < PlayersMoveControl.MaxUG)
            {
                PlayersMoveControl.UG += RecoveryControl.RecoveryCoin;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
            }
            else
            {
                PlayersMoveControl.UG = PlayersMoveControl.MaxUG;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
            }
            if(PlayersMoveControl.Maxlife < PlayersMoveControl.life + RecoveryControl.Recoverypoint)
            {
                //体力回復音
                PlayersMoveControl.life = PlayersMoveControl.Maxlife;
                Debug.Log("HP: " + PlayersMoveControl.life);
            }
            else
            {
                //体力回復音
                PlayersMoveControl.life += RecoveryControl.Recoverypoint;
                Debug.Log("HP: " + PlayersMoveControl.life);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && CoinControl.Coin >= AbilityCoin && AbilityStatus == false && AbilityCT == false && Time.timeScale == 1)
        {
            //バチバチ音(15秒)

            AbilityCT = true;
            AbilityStatus = true;
            IconControl5.c = true; 
            CoinControl.Coin -= AbilityCoin;
            CTcontrol.AbilityStockTime2 = TimeControl.Time + 10;
            CTcontrol.AbilityStockTime = CTcontrol.AbilityStockTime2 + CTcontrol.AbilityCT;
            if (PlayersMoveControl.UG < PlayersMoveControl.MaxUG)
            {
                PlayersMoveControl.UG += AbilityCoin;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
            }
            else
            {
                PlayersMoveControl.UG = PlayersMoveControl.MaxUG;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
            }
            Debug.Log("コインの枚数: " + CoinControl.Coin);
            Debug.Log("固有能力有効化");
        }
        if(Input.GetKeyDown(KeyCode.Alpha6) && PlayersMoveControl.UG >= PlayersMoveControl.MaxUG && UrutoCT == false && Time.timeScale == 1)
            {
                PlayersMoveControl.UG = 0;
                UrutoCT = true;
                AvoidjudgmentStatus = true;
                IconControl6.c = true; 
                CTcontrol.UrutoStockTime2 = TimeControl.Time + 30;
                CTcontrol.UrutoStockTime = CTcontrol.UrutoStockTime2 + CTcontrol.UrutoCT;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
                //ウルトBGM

                PlayersMoveControl.StaminaConsumption = 0;
                PlayersMoveControl.StaminaConsumptionj = 0;
                PlayersMoveControl.SPlayerUGmov = true;
                PlayersMoveControl.moveSpeed = SPlayermoveSpeed * 1.5f;
                Debug.Log("ウルト有効化");
            }
    }
 
    void OnTriggerStay(Collider Collider)
    {
        if(Collider.gameObject.tag == "AttackInhibition")
        {
            a = true;
        }
    }

    void OnTriggerExit(Collider Leave)
    {
        if(Leave.gameObject.tag == "AttackInhibition")
        {
            a = false;
        }
    }
}