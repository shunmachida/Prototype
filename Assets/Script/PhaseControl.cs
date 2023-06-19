using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhaseControl : MonoBehaviour
{
    public Image Phase;
    void Start()
    {
        Color color = Phase.GetComponent<Image>().color;
        color.a = 0f;
        Phase.GetComponent<Image>().color = color;
        //Phase.GetComponent<Image>().color = new Color(0f / 255.0f, 0f / 255.0f, 0f / 255.0f, 255.0f / 255.0f);
    }

    
    void Update()
    {
        
    }
}
