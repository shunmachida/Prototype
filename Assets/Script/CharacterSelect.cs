using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public static string Character;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Small() 
    {
        Character = ("Small");
    }

    public void Default()
    {
        Character = ("Default");
    }

    public void Big()
    {
        Character = ("Big");
    }
}
