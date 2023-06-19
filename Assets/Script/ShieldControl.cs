using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour
{
    public static int t = 7;
    public static int ShieldCoin = 15;
    public static bool Shieldr = false;
    public static bool Shieldstate = false;
    public static bool relay = false;
    public GameObject Shield;
    void Start()
    {
        Shield.SetActive(Shieldstate);
        Shieldr = false;
    }
    void Update()
    {
        Shield.SetActive(Shieldstate);
    }
}
