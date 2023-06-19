using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersReverseMoveControl : MonoBehaviour
{
    Vector3 angle;
    Vector3 relativeposition;
    Vector3 parentTr;

    void Start()
    {
        angle = transform.eulerAngles;//角度を取得して固定
        relativeposition = transform.localPosition;//親のオブジェクトから相対な位置を取得
    }
    void Update()
    {

        if (true)//常に位置を調整する
        {
            /*parent = 親のTransformを取得する*/
            parentTr = transform.parent.position;
            transform.position = parentTr + relativeposition;
        }

        if (true)//常に回転を調整する
        {
            transform.eulerAngles = angle;
        }
    }
}
