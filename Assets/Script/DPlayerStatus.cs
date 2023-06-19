using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DPlayerStatus : MonoBehaviour
{
    public static float Maxlife = 6;
    public static double MaxStamina = 10;
    public static float DPlayermoveSpeed = 10;
    public static float DDashSpeed = DPlayermoveSpeed * 2;
    float DPlayerjumpPower = 6;
    public static int AbilityCoin = 20;
    public static int MaxCoin = 100;
    public static float MaxUG = 100;
    public bool AbilityStatus = false;
    public static bool AbilityCT = false;
    public static bool DUStateControl = false;
    public static bool UrutoCT = false;
    public static bool UCoinStatus = true;
    public bool CallLimt = true;
    public static int MaxUCoinCuont = 10;
    public static int UCoinCuont;
    public GameObject Bulletcall;
    public GameObject Bombcall;
    public Material DamageMaterial;
    public Material NormalMaterial;
    public GameObject UCoinPrefab;
    public Text AbilityText;
    public Text UGText;
    bool e = false;
    void Start()
    {
        CoinControl.GetCoin = 5;
        PlayersMoveControl.AbilityCoin = AbilityCoin;
        PlayersMoveControl.DashSpeed = DDashSpeed;
        PlayersMoveControl.MaxUG = MaxUG;
        PlayersMoveControl.MaxStamina = MaxStamina;
        PlayersMoveControl.Maxlife = Maxlife;
        CoinControl.MaxCoin = MaxCoin;
        PlayersMoveControl.moveSpeed = DPlayermoveSpeed;
        PlayersMoveControl.jumpPower = DPlayerjumpPower;
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
            AbilityStatus = false;
            IconControl5.c = false;
            PlayersMoveControl.StaminaConsumption = 0.01f;
            PlayersMoveControl.StaminaConsumptionj = 2;
        }
        if(CTcontrol.AbilityStockTime < TimeControl.Time)
        {
            IconControl5.b = false; 
            AbilityCT = false;
        }

         if(CTcontrol.UrutoStockTime2 < TimeControl.Time)
        {
            IconControl6.b = true;  
            IconControl6.c = false;
            UCoinStatus = false;
            DUStateControl = false;
            UCoinCuont = 0;
            //ウルト終了BGM(ウルトコイン)

            //ゲーム内音再生(最初っから)
            
        }
        if(CTcontrol.UrutoStockTime < TimeControl.Time)
        {
            IconControl6.b = false;
            UrutoCT = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha1) && CoinControl.Coin >= BulletController.ballCoin && Time.timeScale == 1 && e == false)
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
        if(Input.GetKeyDown(KeyCode.Alpha2) && CoinControl.Coin >= BombControl.BombCoin && BombControl.Bombr == false && Time.timeScale == 1 && e == false)
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
                //体力回復

                PlayersMoveControl.life = PlayersMoveControl.Maxlife;
                Debug.Log("HP: " + PlayersMoveControl.life);
            }
            else
            {
                //体力回復

                PlayersMoveControl.life += RecoveryControl.Recoverypoint;
                Debug.Log("HP: " + PlayersMoveControl.life);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && CoinControl.Coin >= AbilityCoin && AbilityStatus == false && Time.timeScale == 1 && AbilityCT == false)
        {
            AbilityStatus = true;
            AbilityCT = true;
            IconControl5.c = true;
            CTcontrol.AbilityStockTime2 = TimeControl.Time + 10;
            CTcontrol.AbilityStockTime = CTcontrol.AbilityStockTime2 + CTcontrol.AbilityCT;
            CoinControl.Coin -= AbilityCoin;
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
            //アビリティ音(スタミナの消費軽減)

            PlayersMoveControl.StaminaConsumption *= 0.5;
            PlayersMoveControl.StaminaConsumptionj *= 0.5;
        }
        if(PlayersMoveControl.UG >= PlayersMoveControl.MaxUG && DUStateControl == false)
        {
            if(Input.GetKeyDown(KeyCode.Alpha6) && DUStateControl == false && Time.timeScale == 1 && UrutoCT == false)
            {
                UCoinStatus = true;
                UrutoCT = true;
                IconControl6.c = true;
                CTcontrol.UrutoStockTime2 = TimeControl.Time + 30;
                CTcontrol.UrutoStockTime = CTcontrol.UrutoStockTime2 + CTcontrol.UrutoCT;
                PlayersMoveControl.UG = 0;
                Debug.Log("Ug:" + PlayersMoveControl.UG);
                if(UCoinCuont != MaxUCoinCuont)
                    {
                        UCoinspawn();
                    }
                Debug.Log("中有効化");
                DUStateControl = true;
            }
        }
    }
    
    void UCoinspawn()
    {   
        if(UCoinCuont != 10 && MaxUCoinCuont > 0)
        {
            //ウルトBGM


            for (int i = 0; i < MaxUCoinCuont; i++)
            {
                float x = Random.Range(-30f, 30f);
                float y = 12;
                float z = Random.Range(-30f, 30f);
                Vector3 pos = new Vector3(x, y, z);
                Instantiate(UCoinPrefab, pos, Quaternion.identity);
            }
        }
    }

    void OnTriggerStay(Collider Collider)
    {
        if(Collider.gameObject.tag == "AttackInhibition")
        {
            e = true;
        }
    }

    void OnTriggerExit(Collider Leave)
    {
        if(Leave.gameObject.tag == "AttackInhibition")
        {
            e = false;
        }
    }
}