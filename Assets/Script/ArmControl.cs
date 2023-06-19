using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour
{
    private GameObject playerObject;          
    public static Vector3 ArmV;
    private Vector3 PlayerV;
    bool ArmxLimit = false;
    bool ArmyLimit = false;
    bool ArmzLimit = false;
    bool ArmupLimit = false;
    bool ArmMove = false;
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        ArmyLimit = true;
        ArmzLimit = true;
        ArmupLimit = true;
        //Debug.Log(ArmyLimit);
        //Debug.Log(ArmCall.ArmSpeed);
    }

    void Update()
    {
        PlayerV = playerObject.transform.position;
        ArmV = transform.position;
        Invoke("ArmMovechange",2);
        if(ArmMove == true && Time.timeScale != 0)
        {
            if (PlayerV.x > ArmV.x && ArmxLimit == false)
            {
                ArmV.x = ArmV.x + ArmCall.ArmSpeed;
            }
            else if (PlayerV.x < ArmV.x && ArmxLimit == false)
            {
                ArmV.x = ArmV.x - ArmCall.ArmSpeed;
            }
            
            if (ArmyLimit == false)
            {
                ArmV.y = ArmV.y - ArmCall.ArmSpeed;
            }
            
            if (ArmupLimit == false)
            {
                ArmV.y = ArmV.y + ArmCall.ArmSpeed + 1f;
                if(ArmV.y >= 30)
                {
                    if(ArmCall.ArmSpeed < ArmCall.MaxArmSpeed)
                    {
                        ArmCall.ArmSpeed += 0.001f;
                    }
                    Destroy(gameObject);
                }
            }

            if (PlayerV.z > ArmV.z && ArmzLimit == false)
            {   
                ArmV.z = ArmV.z + ArmCall.ArmSpeed;
            }
            else if (PlayerV.z < ArmV.z && ArmzLimit == false)
            {
                ArmV.z = ArmV.z - ArmCall.ArmSpeed;
            }
        }
        transform.position = ArmV;
    }

    void OnTriggerStay(Collider Collider)
    {
        if(Collider.gameObject.tag == "Xcollision" && ArmzLimit == true)
        {
            ArmxLimit = true;
            ArmzLimit = false;
        }
        
        if(Collider.gameObject.tag == "Zcollision" && ArmxLimit == true)
        {
            ArmzLimit = true;
            ArmyLimit = false;
        }

        if (Collider.gameObject.tag == "Shield" || Collider.gameObject.tag == "Player" || Collider.gameObject.tag == "Ground")
        {
            //アームが接触した時の音
            
            ArmyLimit = true;
            ArmupLimit = false;
        }  
    }
    void ArmMovechange()
    {
        ArmMove = true;
        CancelInvoke();
    }
}