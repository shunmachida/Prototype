using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayersMoveControl.Speed > 3)
        {
            Transform myTransform = this.transform;
            myTransform.Rotate (5, 0, 0);
        }
        
    }
}
