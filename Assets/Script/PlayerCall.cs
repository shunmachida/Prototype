using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCall : MonoBehaviour
{
    public GameObject SmallPlayer;
    public GameObject DefaultPlayer;
    public GameObject BigPlayer;
    
    void Start()
    {
        Vector3 CallPosition = new Vector3(0, 15, 0);
        if(CharacterSelect.Character == "Small")
        {
            Instantiate(SmallPlayer, CallPosition, Quaternion.identity);
        }
        else if(CharacterSelect.Character == "Default")
        {
            Instantiate(DefaultPlayer, CallPosition, Quaternion.identity);
        }
        else if(CharacterSelect.Character == "Big")
        {
            Instantiate(BigPlayer, CallPosition, Quaternion.identity);
        }
        
    }

    void Update()
    {
        
    }
}
