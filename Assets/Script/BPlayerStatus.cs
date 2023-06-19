using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BPlayerStatus : MonoBehaviour
{
    public static float Maxlife = 9;
    public static float MaxOverHeel = 30;
    public static float OverHeel;
    public static double MaxStamina = 10;
    public static float BPlayermoveSpeed = 5;
    public static float BDashSpeed = BPlayermoveSpeed * 2;
    float BPlayerjumpPower = 3;
    public static float  Size = 2.5f;
    public static int MaxCoin = 150;
    public static float MaxUG = 100;
    public static int AbilityCoin = 30;
    bool AbilityStateControl = false;
    public static bool AbilityCT = false;
    bool BUStateControl = false;
    public static bool UrutoCT = false;
    bool RecastStatus = false;
    public GameObject Bulletcall;
    public GameObject Bombcall;
    public GameObject Player;
    public Text AbilityText;
    public Text UGText;
    public Material DamageMaterial;
    public Material NormalMaterial;
    bool f = false;
    int a;
    int b;
    
    void Start()
    {
        CoinControl.GetCoin = 7;
        PlayersMoveControl.AbilityCoin = AbilityCoin;
        PlayersMoveControl.DashSpeed = BDashSpeed;
        PlayersMoveControl.MaxUG = MaxUG;
        PlayersMoveControl.MaxStamina = MaxStamina;
        PlayersMoveControl.Maxlife = Maxlife;
        CoinControl.MaxCoin = MaxCoin;
        PlayersMoveControl.moveSpeed = BPlayermoveSpeed;
        PlayersMoveControl.jumpPower = BPlayerjumpPower;
        PlayersMoveControl.DamageMaterial = DamageMaterial;
        PlayersMoveControl.NormalMaterial = NormalMaterial;
        AbilityText.text = string.Format("{0}", AbilityCoin);
        UGText.text = string.Format("{0}", PlayersMoveControl.MaxUG);
        Debug.Log("HP: " + PlayersMoveControl.life);
    }

    void Update()
    {
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
            IconControl5.b = true;
            AbilityStateControl = false;
            OverHeel = 0;
            IconControl5.c = false;

            if(PlayersMoveControl.Maxlife < PlayersMoveControl.life)
            {
                PlayersMoveControl.life = PlayersMoveControl.Maxlife;
            }
        }

        if(CTcontrol.AbilityStockTime < TimeControl.Time)
        {
            IconControl5.b = false; 
            AbilityCT = false;
        }

        if(CTcontrol.UrutoStockTime2 < TimeControl.Time)
        {
            //ウルトBGM（ストップ）

            //ゲームBGM（スタート）

            IconControl6.b = true;
            BUStateControl = false;
            IconControl6.c = false; 
            Size = 2.5f;
            this.transform.localScale = new Vector3(Size, Size, Size);
            Player.transform.localScale = this.transform.localScale;
            PlayersMoveControl.moveSpeed = 5;
        }
        if(CTcontrol.UrutoStockTime < TimeControl.Time)
        {
            IconControl6.b = false;
            UrutoCT = false;
        }

        if (AbilityStateControl == true && TimeControl.Time == a)
        {
            a = TimeControl.Time + 2;
            PlayersMoveControl.life += 3;
            //アビリティー音(体力の継続回復)

            if(PlayersMoveControl.Maxlife < PlayersMoveControl.life)
            {
                OverHeel += 3;
            }
            Debug.Log(PlayersMoveControl.life);
        }

        if(TimeControl.Time == b)
        {
            b = TimeControl.Time + 2;
            RecastStatus = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha1) && CoinControl.Coin >= BulletController.ballCoin && Time.timeScale == 1 && f == false)
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
        if(Input.GetKeyDown(KeyCode.Alpha2) && CoinControl.Coin >= BombControl.BombCoin && BombControl.Bombr == false && Time.timeScale == 1 && f == false)
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
            //シールドが出るときの音

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

        if(Input.GetKeyDown(KeyCode.Alpha5) && AbilityStateControl == false && Time.timeScale == 1 && AbilityCT == false)
            {
                CoinControl.Coin -= AbilityCoin;
                AbilityStateControl = true;
                IconControl5.c = true; 
                AbilityCT = true;
                a = TimeControl.Time + 2;
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
            }
        if(Input.GetKeyDown(KeyCode.Alpha6) && PlayersMoveControl.UG >= PlayersMoveControl.MaxUG && BUStateControl == false && Time.timeScale == 1 && UrutoCT == false)
        {
            PlayersMoveControl.UG = 0;
            Debug.Log("Ug:" + PlayersMoveControl.UG);
            UrutoCT = true;
            BUStateControl = true;
            IconControl6.c = true; 
            CTcontrol.UrutoStockTime2 = TimeControl.Time + 30;
            CTcontrol.UrutoStockTime = CTcontrol.UrutoStockTime2 + CTcontrol.UrutoCT;
            //巨大化BGM

            //巨大化エフェクト
            
            Size = 5;
            this.transform.localScale = new Vector3(Size, Size, Size);
            Player.transform.localScale = this.transform.localScale;
            PlayersMoveControl.moveSpeed = 2;
        }
    }

    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "arm" && Size >= 5 && RecastStatus == false)
        {
            RecastStatus = true;
            b = TimeControl.Time + 2;
            FGauge.F += 5;
            Debug.Log("F:" + FGauge.F);
        } 

        if(Collider.gameObject.tag == "AttackInhibition")
        {
            f = true;
        }
    }
     
    void OnTriggerExit(Collider Leave)
    {
        if(Leave.gameObject.tag == "AttackInhibition")
        {
            f = false;
        }
    }
}
