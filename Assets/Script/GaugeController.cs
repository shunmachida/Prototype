using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    public Slider HP;
    public Slider Cion;
    public Slider Sutamina;
    public Slider UG;
    public Slider FG;
    void Start()
    {
        HP.value = 1;
        Cion.value = 1;
        Sutamina.value = 1;
        UG.value = 1;
        FG.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HP.value = (float)PlayersMoveControl.life / (float)PlayersMoveControl.Maxlife;
        Cion.value = (float)CoinControl.Coin / (float)CoinControl.MaxCoin; 
        Sutamina.value = (float)PlayersMoveControl.Stamina / (float)PlayersMoveControl.MaxStamina;
        UG.value = (float)PlayersMoveControl.UG / (float)PlayersMoveControl.MaxUG; 
        FG.value = (float)FGauge.F / (float)FGauge.MaxF;
    }
}
