using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    private GameObject playerObject;   
    private Vector3 PlayerV;        
    //public static Vector3 CameraV; 
    public static float Speed = 2;            
    private CinemachineVirtualCamera mainCamera;

    void Start()
    {
       
        mainCamera = GetComponent<CinemachineVirtualCamera>();
        playerObject = GameObject.FindWithTag("Player");
    }
 
    void Update()
    {
        /* PlayerV = playerObject.transform.position;
        transform.position = PlayerV;
        CameraV = transform.position;
        CameraV.x = PlayerV.x + 0.6375f;
        CameraV.y = PlayerV.y + 2.225f;
        CameraV.z = PlayerV.z + -7.862501f;
        transform.position = CameraV;
         */

        if(Input.GetMouseButton(0) && Time.timeScale == 1 && TimeControl.StartTime == -1)
        {
            rotateCamera();
        }
    }
 
    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * Speed,Input.GetAxis("Mouse Y") * Speed, 0);
        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, angle.y); 
        
    }
}