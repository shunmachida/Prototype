using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCall : MonoBehaviour
{
    public static float MaxArmSpeed = 0.5f; 
    public static float ArmSpeed = 0.05f;
    public GameObject Arm;
    void Start()
    {
        InvokeRepeating("armcall",4,2);
    }

    void armcall()
    {
        float x = Random.Range(-45f, 45f);
        float y = Random.Range(22f, 29f);
        float z = Random.Range(-45f, 45f);
        Vector3 CallPosition = new Vector3(x,y,z);
        Instantiate(Arm,CallPosition, Quaternion.identity);
        //アームが出てくる音
        
    }
}
