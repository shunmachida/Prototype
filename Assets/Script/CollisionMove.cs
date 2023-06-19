using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMove : MonoBehaviour
{
    private GameObject playerObject; 
    private Vector3 PlayerV;
    private Vector3 CollisionV;
    
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerV = playerObject.transform.position;
        transform.position = PlayerV;
    }
}
