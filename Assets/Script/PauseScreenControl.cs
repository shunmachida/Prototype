using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseScreenControl : MonoBehaviour
{
    public GameObject OperationExplanation;
    public GameObject Option;

    void Start()
    {
        OperationExplanation.SetActive(false);
        Option.SetActive(false);
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.D))
        {
            OperationExplanation.SetActive(false);
            Option.SetActive(false);
        }
    }

    public void CallOperationExplanation()
    {
        OperationExplanation.SetActive(true);
    }

    public void  CallOption()
    {
        Option.SetActive(true);
    }
}
