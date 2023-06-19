using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayersMoveControl : MonoBehaviour
{
    [SerializeField]  AudioSource source1;
    [SerializeField]  AudioClip clip1;
    public static float moveSpeed;
    public static float DashSpeed;
    public static float moveSpeedNormalization;
    public static float jumpPower;
    public static float Maxlife;
    public static float life = 1;
    public static float MaxStocklife = 3;
    public static float Stocklife = MaxStocklife;
    public static float AbilityCoin;
    public static double MaxStamina;
    public static double Stamina;
    public static double StaminaConsumption = 0.01f;
    public static double StaminaConsumptionj = 2;
    CharacterController ch; 
    public static Transform Players_transform; 
    public static Vector3 Players_moveVelocity;
    public static float Speed;
    public static bool RecoveryLimit = false;
    public static Material DamageMaterial;
    public static Material NormalMaterial;
    public static bool MateriaStatus = false;
    public static bool RecoveryStatus = false;
    public static float MaxUG;
    public static float UG;
    int sa;
    public static bool SPlayerUGmov = false;
    public GameObject Stocklife1;
    public GameObject Stocklife2;
    public GameObject Stocklife3;
    public GameObject Pause;
    //public SeControl sc;
    public static bool TimeC = false;
    bool DamageLimit = false;
    bool DashStatus = false;
    bool a = false;
    bool b = false;
    bool c = false;
    bool d = false;

    void Start()
    {
        moveSpeedNormalization = moveSpeed;
        Debug.Log("スタミナ:" + Stamina);
        //InvokeRepeating("RecoveryLimitChange",0,4);
        ch = GetComponent<CharacterController>(); 
        Players_transform = transform;
        Stamina = MaxStamina;
        life = Maxlife;
        Pause.SetActive(false);
        Debug.Log("HP: " + life);
        Debug.Log("残機 :" + Stocklife);
    }

    void Update()
    {    
        if(TimeControl.StartTime == -1)
        {

            //ウルトがたまった時のSE(if文(UGがMAXUGの時 or 超えたとき))

            if(sa + 2 == TimeControl.Time)
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
            }
            if(MaxStocklife == Stocklife)
            {
                Stocklife1.SetActive(true);
                Stocklife2.SetActive(true);
                Stocklife3.SetActive(true);
            }
            else if(Stocklife == 2)
            {
                Stocklife1.SetActive(true);
                Stocklife2.SetActive(true);
                Stocklife3.SetActive(false);
            }
            else if(Stocklife == 1)
            {
                Stocklife1.SetActive(true);
                Stocklife2.SetActive(false);
                Stocklife3.SetActive(false);
            }
            else if(Stocklife == 0)
            {
                Stocklife1.SetActive(false);
                Stocklife2.SetActive(false);
                Stocklife3.SetActive(false);   
            }

            Debug.Log("通常スピード" + moveSpeed + "ダッシュスピード" + DashSpeed);
            Debug.Log("DashStatus" + DashStatus);
            
            Speed = ch.velocity.magnitude;
            //Debug.Log(moveSpeed);
            if(DashStatus == true)
            {
                moveSpeed = DashSpeed;
            }
            else if(DashStatus == false && SPlayerUGmov == false)
            {
                moveSpeed = moveSpeedNormalization;
            }

            if(MaxStamina <= Stamina || moveSpeed == DashSpeed)
            {
                a = false;
            }
            if (Stamina != MaxStamina && moveSpeed != DashSpeed && a == true)
            {
                if(MaxStamina > Stamina)
                {
                    Stamina += 0.01f;
                    //Debug.Log("スタミナ :" + Stamina);
                }
            }
            else if(Stamina <= 0 && moveSpeed != DashSpeed)
            {
                if(c == false)
                {
                    Debug.Log(5);
                    c = true;
                    Invoke("cChange",2);
                }
            }
            
            if(Input.GetKeyDown(KeyCode.F))
            {
                //FGauge.F += 100;
                UG = MaxUG;
            }
            //ポーズ
                if(Input.GetKeyDown(KeyCode.P) && TimeC == false)
                {
                    TimeC = true;
                    Pause.SetActive(true);
                    Time.timeScale = 0;
                
                }
                else if(Input.GetKeyDown(KeyCode.P) && TimeC == true)
                {
                    TimeC = false;
                    Pause.SetActive(false);
                    Time.timeScale = 1;
                }
                //移動
                if (ch.isGrounded) 
                {
                    Players_moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
                    Players_moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;
                    Players_transform.LookAt(Players_transform.position + new Vector3(Players_moveVelocity.x, 0, Players_moveVelocity.z));
                }
                else
                {
                    Players_moveVelocity.x = 0;
                    Players_moveVelocity.z = 0;
                }
                //スタミナ(ダッシュ)
                if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) && Time.timeScale != 0)
                {
                    if(Stamina > 0)
                    {   
                        //Stamina -= 1f;
                        Stamina -= StaminaConsumption;
                        DashStatus = true;
                    }
                    else if(Stamina <= 0)
                    {
                        DashStatus = false;
                    }
                }
                //スピード
                if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift) && Time.timeScale != 0)
                {
                    if(c == false)
                    {
                        Debug.Log(5);
                        c = true;
                        Invoke("cChange",2);
                    }
                    DashStatus = false;
                }
                //ジャンプ
                if (ch.isGrounded)
                {
                if (Input.GetButtonDown("Jump") && Stamina >= StaminaConsumptionj && Time.timeScale != 0)
                {
                    Stamina -= StaminaConsumptionj;
                    Players_moveVelocity.y = jumpPower;
                    if(c == false)
                    {
                        a = false; 
                        Debug.Log(5);
                        c = true;
                        Invoke("cChange",2);
                    }
                }
            }
            else
            {
                Players_moveVelocity.y += Physics.gravity.y * Time.deltaTime;
                Players_moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
                Players_moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;
                Players_transform.LookAt(Players_transform.position + new Vector3(Players_moveVelocity.x, 0, Players_moveVelocity.z));
            }
            ch.Move(Players_moveVelocity * Time.deltaTime);

            if(MateriaStatus == false)
            {
                GetComponent<MeshRenderer>().material = NormalMaterial;
            }
            else if(MateriaStatus == true)
            {
                GetComponent<MeshRenderer>().material = DamageMaterial;
            }
        }
    }
    
    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "arm" && DamageLimit == false && SPlayerStatus.AvoidjudgmentStatus == true && life > 0 && Stocklife >= 0 && BPlayerStatus.Size <= 4)
        {
            DamageLimit = true;
            MateriaStatus = true;
            Debug.Log(MateriaStatus);
            if(b == false)
            {
                b = true;
                Invoke("DamageLimitC", CTcontrol.DamageLimitCT);
            }
            //Invoke("DamageLimitC", CTcontrol.DamageLimitCT);
            FGauge.F -= 5;
            if(life < 2)
            {
                life = 0;
                if(Stocklife > 0 && life == 0)
                {
                    Stocklife -= 1;
                    life = Maxlife;
                    Debug.Log("残機 :" + Stocklife);
                    Debug.Log("残機を消費してHPを回復しました :" + life);
                }
                Debug.Log("HP :" + life);
            }
            else
            {
                life -= 2;
                Debug.Log("HP :" + life);
            }
        }
        
        
        if(Collider.gameObject.tag == "arm" && DamageLimit == false && SPlayerStatus.AvoidjudgmentStatus == false && life > 0 && Stocklife >= 0 && BPlayerStatus.Size <= 4)
        {
            DamageLimit = true;
            MateriaStatus = true;

            if(b == false)
            {
                b = true;
                Invoke("DamageLimitC", CTcontrol.DamageLimitCT);
            }
            //Invoke("DamageLimitC", CTcontrol.DamageLimitCT);
            if(BPlayerStatus.OverHeel > 2)
            {
                BPlayerStatus.OverHeel -= 2;
            }
            if(life < 2)
            {
                life = 0;
                Debug.Log("HP :" + life);
                if(Stocklife > 0  && life == 0)
                {
                    Stocklife -= 1;
                    life = Maxlife;
                    Debug.Log("残機 :" + Stocklife);
                    Debug.Log("残機を消費してHPを回復しました :" + life);
                } 
            }
            else
            {
                life -= 2;
                if(Stocklife > 0  && life == 0)
                {
                    Stocklife -= 1;
                    life = Maxlife;
                    Debug.Log("残機 :" + Stocklife);
                    Debug.Log("残機を消費してHPを回復しました :" + life);
                } 
                Debug.Log("HP :" + life);
            }
        }
    }

    void DamageLimitC()
    {
        DamageLimit = false;
        MateriaStatus = false;
        Debug.Log(MateriaStatus);
        b = false;
        //CancelInvoke();
    }
    
    void cChange()
    {
        a = true;
        c = false;
    }
}