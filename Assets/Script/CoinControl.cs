using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public GameObject CoinPrefab;
    public static int MaxCoin;
    public static int Coin;
    public static int GetCoin;
    
    void Start()
    {
        InvokeRepeating("Coinspawn",4,5);
    }

    void Coinspawn()
    {
        float x = Random.Range(-30f, 30f);
        float y = 11.5f;
        float z = Random.Range(-30f, 30f);
        Vector3 pos = new Vector3(x, y, z);
       Instantiate(CoinPrefab, pos, Quaternion.identity);
    }
}
